using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using PecaBoa.Core.Extensions;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace PecaBoa.Application.Services;

public class LojistaService : BaseService, ILojistaService
{
    private readonly ILojistaRepository _lojistaRepository;
    private readonly IPasswordHasher<Lojista> _passwordHasher;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LojistaService(IMapper mapper, INotificator notificator, ILojistaRepository lojistaRepository,
        IPasswordHasher<Lojista> passwordHasher, IOptions<AppSettings> appSettings, IEmailService emailService,
        IFileService fileService, IHttpContextAccessor httpContextAccessor) : base(mapper, notificator)
    {
        _lojistaRepository = lojistaRepository;
        _passwordHasher = passwordHasher;
        _emailService = emailService;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
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
                Convert.ToInt32(_httpContextAccessor?.HttpContext?.User.ObterUsuarioId()));
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

    public async Task<LojistaDto?> Cadastrar(CadastrarLojistaDto dto)
    {
        if (dto.Senha != dto.ConfirmacaoSenha)
        {
            Notificator.Handle("As senhas não conferem!");
            return null;
        }

        var lojista = Mapper.Map<Lojista>(dto);
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

    public async Task<LojistaDto?> ObterPorCpf(string cpf) //ToDo: olhar depois
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