using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using PecaBoa.Core.Extensions;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PecaBoa.Application.Services;

public class LojistaAuthService : BaseService, ILojistaAuthService
{
    private readonly ILojistaRepository _lojistaRepository;
    private readonly IPasswordHasher<Lojista> _lojistapasswordHasher;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;

    public LojistaAuthService(IMapper mapper, INotificator notificator, ILojistaRepository lojistaRepository,
        IPasswordHasher<Lojista> lojistapasswordHasher, IEmailService emailService,
        IOptions<AppSettings> appSettings) : base(mapper, notificator)
    {
        _lojistaRepository = lojistaRepository;
        _lojistapasswordHasher = lojistapasswordHasher;
        _emailService = emailService;
        _appSettings = appSettings.Value;
    }

    public async Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto)
    {
        var lojista = await _lojistaRepository.ObterPorEmail(loginDto.Email);
        if (lojista == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        var result = _lojistapasswordHasher.VerifyHashedPassword(lojista, lojista.Senha, loginDto.Senha);
        if (result != PasswordVerificationResult.Failed)
        {
            return new UsuarioAutenticadoDto
            {
                Id = lojista.Id,
                Email = lojista.Email,
                Nome = lojista.Nome,
                Token = await CreateTokenLojista(lojista)
            };
        }

        Notificator.Handle("Combinação de email e senha incorreta!");
        return null;
    }

    public async Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaLojistaDto dto)
    {
        var usuario = await _lojistaRepository.FirstOrDefault(c =>
            c.Email == dto.Email && c.CodigoResetarSenha == dto.CodigoResetarSenha);
        if (usuario == null)
        {
            Notificator.Handle("Código inválido ou expirado!");
            return false;
        }

        if (usuario.CodigoResetarSenha == dto.CodigoResetarSenha && usuario.CodigoResetarSenhaExpiraEm >= DateTime.Now)
        {
            return true;
        }

        Notificator.Handle("Código inválido ou expirado!");
        return false;
    }

    public async Task RecuperarSenha(RecuperarSenhaLojistaDto dto)
    {
        var lojista = await _lojistaRepository.FirstOrDefault(f => f.Email == dto.Email);
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

    public async Task AlterarSenha(AlterarSenhaLojistaDto dto)
    {
        var lojista = await _lojistaRepository.FirstOrDefault(c =>
            c.Email == dto.Email && c.CodigoResetarSenha == dto.CodigoResetarSenha);
        if (lojista == null)
        {
            Notificator.Handle("Cóidigo inválido ou expirado!");
            return;
        }

        if (!(lojista.CodigoResetarSenha == dto.CodigoResetarSenha &&
              lojista.CodigoResetarSenhaExpiraEm >= DateTime.Now))
        {
            Notificator.Handle("Código inválido ou expirado!");
            return;
        }

        if (!dto.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return;
        }

        lojista.Senha = _lojistapasswordHasher.HashPassword(lojista, dto.Senha);
        lojista.CodigoResetarSenha = null;
        lojista.CodigoResetarSenhaExpiraEm = null;

        _lojistaRepository.Alterar(lojista);
        if (!await _lojistaRepository.UnitOfWork.Commit())
        {
            Notificator.Handle("Não foi possível alterar a senha");
        }
    }

    public Task<string> CreateTokenLojista(Lojista lojista)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, lojista.Id.ToString()),
                new Claim(ClaimTypes.Name, lojista.Nome),
                new Claim(ClaimTypes.Email, lojista.Email),
                new Claim("TipoUsuario", ETipoUsuario.Lojista.ToDescriptionString()),
                new Claim("Administrador", ETipoUsuario.Lojista.ToDescriptionString()),
                new Claim("Lojista", ETipoUsuario.Lojista.ToDescriptionString()),
                new Claim("Usuario", ETipoUsuario.Lojista.ToDescriptionString()),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}