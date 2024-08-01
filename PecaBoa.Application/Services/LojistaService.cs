using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Extensions;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PecaBoa.Application.Adapters.Asaas.Application.Contracts;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Customers;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Subscriptions;
using PecaBoa.Application.Dtos.V1.Lojista.Inscricoes;
using PecaBoa.Application.Dtos.V1.Lojista.LojistaCartoesDeCredito;

namespace PecaBoa.Application.Services;

public class LojistaService : BaseService, ILojistaService
{
    private readonly ILojistaRepository _lojistaRepository;
    private readonly IPasswordHasher<Lojista> _passwordHasher;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICustomerService _customerService;
    private readonly ISubscriptionService _subscriptionService;
    private readonly ILojistaCartaoDeCreditoService _lojistaCartaoDeCreditoService;
    private readonly IPaymentService _paymentService;
    private readonly IFileService _fileService;

    public LojistaService(IMapper mapper, INotificator notificator, ILojistaRepository lojistaRepository,
        IPasswordHasher<Lojista> passwordHasher, IOptions<AppSettings> appSettings, IEmailService emailService, IHttpContextAccessor httpContextAccessor, ICustomerService customerService, ISubscriptionService subscriptionService, ILojistaCartaoDeCreditoService lojistaCartaoDeCreditoService, IPaymentService paymentService, IFileService fileService) : base(mapper, notificator)
    {
        _lojistaRepository = lojistaRepository;
        _passwordHasher = passwordHasher;
        _emailService = emailService;
        _httpContextAccessor = httpContextAccessor;
        _customerService = customerService;
        _subscriptionService = subscriptionService;
        _lojistaCartaoDeCreditoService = lojistaCartaoDeCreditoService;
        _paymentService = paymentService;
        _fileService = fileService;
        _appSettings = appSettings.Value;
    }


    public async Task<PagedDto<LojistaDto>> Buscar(BuscarLojistaDto dto)
    {
        var lojista = await _lojistaRepository.Buscar(dto);
        return Mapper.Map<PagedDto<LojistaDto>>(lojista);
    }

    public async Task<PagedDto<LojistaDto>> BuscarAnuncio()
    {
        var usuarioLogado =
            await _lojistaRepository.ObterPorId(
                Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()));
        if (usuarioLogado == null)
        {
            Notificator.Handle("Não foi possível identificar o usuário logado");
        }

        var lojista = await _lojistaRepository.Buscar(new BuscarLojistaDto
            { Cidade = usuarioLogado?.Cidade, AnuncioPago = true });

        if (lojista.Itens.Count == 0)
        {
            return Mapper.Map<PagedDto<LojistaDto>>(await _lojistaRepository.Buscar(new BuscarLojistaDto{AnuncioPago = true}));
        }

        return Mapper.Map<PagedDto<LojistaDto>>(lojista);
    }
    
    public async Task VerifyPayment(SubscriptionHookDto dto)
    {
        await _paymentService.VerifyPayment(dto);
    }

    public async Task<LojistaDto?> Cadastrar(CadastrarLojistaDto dto)
    {
        if (dto.Senha != dto.ConfirmacaoSenha)
        {
            Notificator.Handle("As senhas não conferem!");
            return null;
        }

        var lojista = Mapper.Map<Lojista>(dto);
        
        if (dto.Foto is { Length : > 0 })
        {
            lojista.Foto = await _fileService.Upload(dto.Foto);
        }
        
        if (!await Validar(lojista))
        {
            return null;
        }

        lojista.Senha = _passwordHasher.HashPassword(lojista, lojista.Senha);
        lojista.Uf = lojista.Uf.ToLower();
        lojista.CriadoEm = DateTime.SpecifyKind(lojista.CriadoEm, DateTimeKind.Utc);
        _lojistaRepository.Adicionar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.Handle("Não foi possível adicionar o lojista");
        return null;
    }
    
    public async Task<SubscriptionResponseDto?> Inscricao(CadastrarInscricaoDto dto)
    {
        var lojista = await _lojistaRepository.ObterPorId(dto.LojistaId);
        if (lojista is null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        var customers = await _customerService.GetByEmail(lojista.Email);
        if (customers is null)
        {
            return null;
        }

        var customer = customers.Any()
            ? customers.First()
            : await _customerService.Create(
                new CreateCustomerDto
                {
                    Email = lojista.Email,
                    Name = lojista.Nome,
                    Phone = lojista.Telefone,
                    CpfCnpj = lojista.Cnpj ?? lojista.Cpf
                });
        if (customer is null)
        {
            Notificator.Handle("Assas - Um erro ocorreu ao tentar obter o cliente.");
            return null;
        }

        var subscription = await _subscriptionService.GetByCustomerId(customer.Id);
        if (subscription is not null && subscription.Data!.Any())
        {
            Notificator.Handle("Assas - Já existe uma assinatura ativa para este cliente.");
            return null;
        }

        if (dto.IsRecurrent)
        {
            if (dto.CreditCard is null || dto.CreditCardHolderInfo is null)
            {
                Notificator.Handle(
                    "Para assinaturas recorrentes é necessário informar os dados do cartão de crédito e do titular do cartão.");
                return null;
            }
        }

        var subscriptionDto = new ValueTuple<SubscriptionDto, SubscriptionDebitDto>
        {
            Item1 = new SubscriptionDto
            {
                Customer = customer.Id,
                BillingType = "CREDIT_CARD",
                Value = _appSettings.PlatformValue,
                NextDueDate = DateTime.Now.AddDays(_appSettings.FreeUsageDays).Date,
                Cycle = "MONTHLY",
                MaxPayments = dto.IsRecurrent ? 999999 : 1,
                CreditCard = !dto.IsRecurrent
                    ? null
                    : new CreditCard
                    {
                        HolderName = dto.CreditCard!.HolderName.Trim(),
                        Number = dto.CreditCard.Number.SomenteNumeros()?.Replace(" ", "").Trim(),
                        ExpiryMonth = dto.CreditCard.ExpiryMonth.Trim(),
                        ExpiryYear = dto.CreditCard.ExpiryYear.Trim(),
                        Ccv = dto.CreditCard.Ccv.Trim()
                    },
                CreditCardHolderInfo = !dto.IsRecurrent
                    ? null
                    : new CreditCardHolderInfo
                    {
                        Name = dto.CreditCardHolderInfo!.Name.Trim(),
                        Email = dto.CreditCardHolderInfo.Email.Trim(),
                        CpfCnpj = dto.CreditCardHolderInfo.CpfCnpj.SomenteNumeros()?.Trim(),
                        PostalCode = dto.CreditCardHolderInfo.PostalCode.Trim(),
                        AddressNumber = dto.CreditCardHolderInfo.AddressNumber.Trim(),
                        Phone = dto.CreditCardHolderInfo.Phone.SomenteNumeros()?.Trim()
                    }
            },
            Item2 = new SubscriptionDebitDto
            {
                Customer = customer.Id,
                BillingType = "CREDIT_CARD",
                Value = _appSettings.PlatformValue,
                NextDueDate = DateTime.Now.AddDays(_appSettings.FreeUsageDays).Date,
                Cycle = "MONTHLY",
                MaxPayments = 1
            }
        };

        var newSubscription = dto.IsRecurrent
            ? await _subscriptionService.Create(subscriptionDto.Item1)
            : dto.CreditCard is not null || dto.CreditCardHolderInfo is not null
                ? await _subscriptionService.Create(subscriptionDto.Item1)
                : await _subscriptionService.Create(subscriptionDto.Item2);

        if (newSubscription is null)
        {
            Notificator.Handle("Um erro ocorrreu ao criar a assinatura.");
            return null;
        }

        if (dto.CreditCard is not null && dto.CreditCardHolderInfo is not null)
        {
            await _lojistaCartaoDeCreditoService.Create(new CreateLojistaCartaoDeCreditoDto
            {
                HolderName = dto.CreditCard.HolderName,
                Number = dto.CreditCard.Number!,
                ExpiryMonth = dto.CreditCard.ExpiryMonth,
                ExpiryYear = dto.CreditCard.ExpiryYear,
                Ccv = dto.CreditCard.Ccv,
                Name = dto.CreditCardHolderInfo.Name,
                Email = dto.CreditCardHolderInfo.Email,
                CpfCnpj = dto.CreditCardHolderInfo.CpfCnpj!,
                PostalCode = dto.CreditCardHolderInfo.PostalCode,
                AddressNumber = dto.CreditCardHolderInfo.AddressNumber,
                Phone = dto.CreditCardHolderInfo.Phone!,
                CreditCardToken = newSubscription.CreditCard?.CreditCardToken,
                LojistaId = lojista.Id,
                LastNumbers = dto.CreditCard.Number![(dto.CreditCard.Number.Length - 4)..]
            });
        }

        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return newSubscription;
        }

        Notificator.Handle("Um erro ocorreu ao atualizar o usuário.");
        return null;
    } 

    public async Task<LojistaDto?> Alterar(int id, AlterarLojistaDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, lojista);
        
        if (dto.Foto is { Length : > 0 })
        {
            lojista.Foto = await _fileService.Upload(dto.Foto);
        }
        else
        {
            lojista.Foto = null;
        }
        
        if (!await Validar(lojista))
        {
            return null;
        }

        lojista.Uf = lojista.Uf.ToLower();
        lojista.AtualizadoEm = DateTime.SpecifyKind(lojista.AtualizadoEm, DateTimeKind.Utc);
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.Handle("Não foi possível alterar o lojista");
        return null;
    }

    public async Task<LojistaDto?> ObterPorId(int id)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista != null)
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<LojistaDto?> ObterPorEmail(string email)
    {
        var lojista = await _lojistaRepository.ObterPorEmail(email);
        if (lojista != null)
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<LojistaDto?> ObterPorCnpj(string cnpj)
    {
        var lojista = await _lojistaRepository.ObterPorCnpj(cnpj);
        if (lojista != null)
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<LojistaDto?> ObterPorCpf(string cpf)
    {
        var lojista = await _lojistaRepository.ObterPorCpf(cpf);
        if (lojista != null)
        {
            return Mapper.Map<LojistaDto>(lojista);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }


    public async Task AlterarSenha(int id)
    {
        var lojista = await _lojistaRepository.FirstOrDefault(f => f.Id == id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        var codigoExpiraEmHoras = 3;
        lojista.CodigoResetarSenha = Guid.NewGuid();
        lojista.CodigoResetarSenhaExpiraEm = DateTime.Now.AddHours(codigoExpiraEmHoras);
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            _emailService.Enviar(
                lojista.Email,
                "Seu link para alterar a senha",
                "Usuario/CodigoResetarSenha",
                new
                {
                    lojista.Nome,
                    lojista.Email,
                    Codigo = lojista.CodigoResetarSenha,
                    Url = _appSettings.UrlComum,
                    ExpiracaoEmHoras = codigoExpiraEmHoras
                });
        }
    }

    public async Task AlterarSenhaSemEnvioEmail(AlterarSenhaLojistaSemEnvioEmailDto dto)
    {
        if (dto.Senha != dto.ConfirmarSenha)
        {
            Notificator.Handle("As senhas não conferem!");
            return;
        }
        
        var lojista = await _lojistaRepository.ObterPorId(Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()));
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        lojista.Senha = _passwordHasher.HashPassword(lojista, dto.Senha);
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possivel alterar a senha");
    }

    public async Task Desativar(int id)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        lojista.Desativado = true;
        lojista.AtualizadoEm = DateTime.SpecifyKind(lojista.AtualizadoEm, DateTimeKind.Utc);
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível desativar o lojista");
    }

    public async Task Reativar(int id)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        lojista.Desativado = false;
        lojista.AtualizadoEm = DateTime.SpecifyKind(lojista.AtualizadoEm, DateTimeKind.Utc);
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível reativar o lojista");
    }

    public async Task AtivarAnuncio(int id)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        //lojista.AnuncioPago = true;
        //lojista.DataPagamentoAnuncio = DateTime.Now;
        //lojista.DataExpiracaoAnuncio = lojista.DataPagamentoAnuncio.Value.AddMonths(1);
        lojista.AtualizadoEm = DateTime.Now;
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível ativar o anúncio para o lojista");
    }

    public async Task DesativarAnuncio(int id)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        //lojista.AnuncioPago = false;
        lojista.AtualizadoEm = DateTime.Now;
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível desativar o anúncio para o lojista");
    }

    public async Task AlterarDescricao(int id, string descricao)
    {
        var lojista = await _lojistaRepository.ObterPorId(id);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        lojista.Descricao = descricao;
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível reativar o lojista");
    }

    public async Task Remover(int id)
    {
        var lojista = await _lojistaRepository.FirstOrDefault(c => c.Id == id);
        if (lojista == null)
        {
            Notificator.Handle("Não existe um lojista com o id informado");
            return;
        }

        _lojistaRepository.Remover(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível remover o lojista");
    }

    public async Task AlterarFoto(AlterarFotoLojistaDto dto)
    {
        var lojista = await _lojistaRepository.ObterPorId(Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()));
        if (lojista is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        if (dto.Foto is { Length : > 0 })
        {
            lojista.Foto = await _fileService.Upload(dto.Foto);
        }
        
        _lojistaRepository.Alterar(lojista);
        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível alterar a foto");
    }

    public async Task RemoverFoto()
    {
        var lojista = await _lojistaRepository.ObterPorId(Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()));
        if (lojista is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        lojista.Foto = null;
        _lojistaRepository.Alterar(lojista);

        if (await _lojistaRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível alterar a foto");
    }

    private async Task<bool> Validar(Lojista lojista)
    {
        if (!lojista.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var lojistaExistente = await _lojistaRepository.FirstOrDefault(c =>
            (c.Email == lojista.Email || c.Cnpj == lojista.Cnpj) && c.Id != lojista.Id);

        if (lojistaExistente != null)
        {
            Notificator.Handle("Já existe um lojista cadastrado com essas identificações");
        }

        return !Notificator.HasNotification;
    }
}