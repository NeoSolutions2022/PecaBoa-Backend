using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace PecaBoa.Application.Services;

public class UsuarioService : BaseService, IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IFileService _fileService;
    private readonly AppSettings _appSettings;
    private readonly IEmailService _emailService;

    public UsuarioService(IMapper mapper, INotificator notificator, IUsuarioRepository usuarioRepository, IPasswordHasher<Usuario> passwordHasher, IFileService fileService, IOptions<AppSettings> appSettings, IEmailService emailService) : base(mapper, notificator)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
        _fileService = fileService;
        _emailService = emailService;
        _appSettings = appSettings.Value;
    }

    public async Task<PagedDto<UsuarioDto>> Buscar(BuscarUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.Buscar(dto);
        return Mapper.Map<PagedDto<UsuarioDto>>(usuario);
    }

    public async Task<UsuarioDto?> Cadastrar(CadastrarUsuarioDto dto)
    {
        if (!ValidarAnexos(dto))
        {
            return null;
        }
        
        if (dto.Senha != dto.ConfirmacaoSenha)
        {
            Notificator.Handle("As senhas não conferem!");
            return null;
        }
        
        var usuario = Mapper.Map<Usuario>(dto);
        if (!await Validar(usuario))
        {
            return null;
        }

        //if (dto.Foto is {Length: > 0})
        //{
        //    Usuario.Foto = await _fileService.Upload(dto.Foto, EUploadPath.FotoFornecedor);
        //}
        
        usuario.Senha = _passwordHasher.HashPassword(usuario, usuario.Senha);
        usuario.Uf = usuario.Uf.ToLower();
        usuario.CriadoEm = DateTime.Now;
        _usuarioRepository.Adicionar(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }
        
        Notificator.Handle("Não foi possível adicionar o Usuario");
        return null;
    }

    public async Task<UsuarioDto?> Alterar(int id, AlterarUsuarioDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var usuario = await _usuarioRepository.ObterPorId(id);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, usuario);
        if (!await Validar(usuario))
        {
            return null;
        }
        
        usuario.Senha = _passwordHasher.HashPassword(usuario, usuario.Senha);
        usuario.Uf = usuario.Uf.ToLower();
        usuario.AtualizadoEm = DateTime.Now;
        _usuarioRepository.Alterar(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }
        
        Notificator.Handle("Não foi possível alterar o Usuario");
        return null;
    }

    public async Task<UsuarioDto?> ObterPorId(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);
        if (usuario != null)
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<UsuarioDto?> ObterPorEmail(string email)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(email);
        if (usuario != null)
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<UsuarioDto?> ObterPorCpf(string cpf)
    {
        var usuario = await _usuarioRepository.ObterPorCpf(cpf);
        if (usuario != null)
        {
            return Mapper.Map<UsuarioDto>(usuario);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task AlterarSenha(int id)
    {
        var usuario = await _usuarioRepository.FistOrDefault(f => f.Id == id);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        var codigoExpiraEmHoras = 3;
        usuario.CodigoResetarSenha = Guid.NewGuid();
        usuario.CodigoResetarSenhaExpiraEm = DateTime.Now.AddHours(codigoExpiraEmHoras);
        _usuarioRepository.Alterar(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            _emailService.Enviar(
                usuario.Email,
                "Seu link para alterar a senha",
                "Usuario/CodigoResetarSenha",
                new
                {
                    Nome = usuario.NomeSocial ?? usuario.Nome,
                    usuario.Email,
                    Codigo = usuario.CodigoResetarSenha,
                    Url = _appSettings.UrlComum,
                    ExpiracaoEmHoras = codigoExpiraEmHoras
                });
        }
    }

    public async Task Desativar(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        usuario.Desativado = true;
        usuario.AtualizadoEm = DateTime.Now;
        _usuarioRepository.Alterar(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar o Usuario");
    }

    public async Task Reativar(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        usuario.Desativado = false;
        usuario.AtualizadoEm = DateTime.Now;
        _usuarioRepository.Alterar(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível reativar o Usuario");
    }

    public async Task Remover(int id)
    {
        var usuario = await _usuarioRepository.FistOrDefault(c => c.Id == id);
        if (usuario == null)
        {
            Notificator.Handle("Não existe um Usuario com o id informado");
            return;
        }
        
        _usuarioRepository.Remover(usuario);
        if (await _usuarioRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível remover o Usuario");
        return;
    }

    private async Task<bool> Validar(Usuario usuario)
    {
        if (!usuario.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
        
        var usuarioExistente = await _usuarioRepository.FistOrDefault(c =>
            c.Cpf == usuario.Cpf || c.Email == usuario.Email && c.Id != usuario.Id);
        if (usuarioExistente != null)
        {
            Notificator.Handle("Já existe um usuário cadastrador com uma ou mais identificações");
        }
        
        return !Notificator.HasNotification;
    }
    
    private bool ValidarAnexos(CadastrarUsuarioDto dto)
    {
        if (dto.Foto?.Length > 10000000)
        {
            Notificator.Handle("Foto deve ter no máximo 10Mb");
        }

        //if (dto.Foto != null && dto.Foto.FileName.Split(".").Last() != "jfif" &&
        //    dto.Foto.FileName.Split(".").Last() != "png" && dto.Foto.FileName.Split(".").Last() != "jpg" 
        //    && dto.Foto.FileName.Split(".").Last() != "jpeg")
        //{
        //    Notificator.Handle("Foto deve do tipo png, jfif ou jpg");
        //}

        return !Notificator.HasNotification;
    }
    
    private async Task<bool> ManterFoto(IFormFile foto, Usuario usuario)
    {
        usuario.Foto = await _fileService.Upload(foto, EUploadPath.FotoUsuario);
        return true;
    }
}