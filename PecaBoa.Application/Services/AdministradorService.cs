using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Administrador;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace PecaBoa.Application.Services;

public class AdministradorService : BaseService, IAdministradorService
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IPasswordHasher<Administrador> _passwordHasher;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;

    public AdministradorService(IMapper mapper, INotificator notificator, IAdministradorRepository administradorRepository, IPasswordHasher<Administrador> passwordHasher, IEmailService emailService, IOptions<AppSettings> appSettings) : base(mapper, notificator)
    {
        _administradorRepository = administradorRepository;
        _passwordHasher = passwordHasher;
        _emailService = emailService;
        _appSettings = appSettings.Value;
    }

    public async Task<PagedDto<AdministradorDto>> Buscar(BuscarAdministradorDto dto)
    {
        var administrador = await _administradorRepository.Buscar(dto);
        return Mapper.Map<PagedDto<AdministradorDto>>(administrador);
    }

    public async Task<AdministradorDto?> Adicionar(AdicionarAdministradorDto dto)
    {
        var administrador = Mapper.Map<Administrador>(dto);
        if (!await Validar(administrador))
        {
            return null;
        }
        
        administrador.Senha = _passwordHasher.HashPassword(administrador, administrador.Senha);
        _administradorRepository.Adicionar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.Handle("Não foi possível adicionar o administrador");
        return null;
    }

    public async Task<AdministradorDto?> Alterar(int id, AlterarAdministradorDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, administrador);
        if (!await Validar(administrador))
        {
            return null;
        }
        
        administrador.Senha = _passwordHasher.HashPassword(administrador, administrador.Senha);
        _administradorRepository.Alterar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.Handle("Não foi possível alterar o administrador");
        return null;
    }

    public async Task<AdministradorDto?> ObterPorId(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador != null)
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<AdministradorDto?> ObterPorEmail(string email)
    {
        var administrador = await _administradorRepository.ObterPorEmail(email);
        if (administrador != null)
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task Desaticar(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        administrador.Desativado = true;
        _administradorRepository.Alterar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar o administrador");
    }
    
    public async Task Reativar(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        administrador.Desativado = false;
        _administradorRepository.Alterar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível reativar o administrador");
    }

    public async Task Remover(int id)
    {
        var lojista = await _administradorRepository.FistOrDefault(c => c.Id == id);
        if (lojista == null)
        {
            Notificator.Handle("Não existe um lojista com o id informado");
            return;
        }

        _administradorRepository.Remover(lojista);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível remover o lojista");
    }

    public async Task AlterarSenha(int id)
    {
        var administrador = await _administradorRepository.FistOrDefault(f => f.Id == id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        var codigoExpiraEmHoras = 3;
        administrador.CodigoResetarSenha = Guid.NewGuid();
        administrador.CodigoResetarSenhaExpiraEm = DateTime.Now.AddHours(codigoExpiraEmHoras);
        _administradorRepository.Alterar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            _emailService.Enviar(
                administrador.Email,
                "Seu link para alterar a senha",
                "Usuario/CodigoResetarSenha",
                new
                {
                    administrador.Nome,
                    administrador.Email,
                    Codigo = administrador.CodigoResetarSenha,
                    Url = _appSettings.UrlComum,
                    ExpiracaoEmHoras = codigoExpiraEmHoras
                });
        }
    }

    private async Task<bool> Validar(Administrador administrador)
    {
        if (!administrador.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var administradorExistente =
            await _administradorRepository.FistOrDefault(
                c => c.Email == administrador.Email && c.Id != administrador.Id);
        if (administradorExistente != null)
        {
            Notificator.Handle("Já existe um administrador com esse email!");
        }

        return !Notificator.HasNotification;
    }
}