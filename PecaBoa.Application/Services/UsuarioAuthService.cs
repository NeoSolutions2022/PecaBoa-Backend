﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Usuario;
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
using Newtonsoft.Json;
using PecaBoa.Core.Authorization;

namespace PecaBoa.Application.Services;

public class UsuarioAuthService : BaseService, IUsuarioAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IEmailService _emailService;
    private readonly IGrupoAcessoRepository _grupoAcessoRepository;
    private readonly AppSettings _appSettings;

    public UsuarioAuthService(IMapper mapper, INotificator notificator, IUsuarioRepository usuarioRepository,
        IPasswordHasher<Usuario> passwordHasher, IEmailService emailService, IOptions<AppSettings> appSettings, IGrupoAcessoRepository grupoAcessoRepository) : base(
        mapper, notificator)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
        _emailService = emailService;
        _grupoAcessoRepository = grupoAcessoRepository;
        _appSettings = appSettings.Value;
    }

    public async Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(loginDto.Email);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, loginDto.Senha);
        if (result != PasswordVerificationResult.Failed)
        {
            return new UsuarioAutenticadoDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Token = await CreateTokenUsuario(usuario)
            };
        }

        Notificator.Handle("Combinação de email e senha incorreta!");
        return null;
    }

    public async Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.FirstOrDefault(c =>
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

    public async Task RecuperarSenha(RecuperarSenhaUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.FirstOrDefault(f => f.Email == dto.Email);
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
                    usuario.Nome,
                    usuario.Email,
                    Codigo = usuario.CodigoResetarSenha,
                    Url = _appSettings.UrlComum,
                    ExpiracaoEmHoras = codigoExpiraEmHoras
                });
        }
    }

    public async Task AlterarSenha(AlterarSenhaUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.FirstOrDefault(c =>
            c.Email == dto.Email && c.CodigoResetarSenha == dto.CodigoResetarSenha);
        if (usuario == null)
        {
            Notificator.Handle("Cóidigo inválido ou expirado!");
            return;
        }

        if (!(usuario.CodigoResetarSenha == dto.CodigoResetarSenha &&
              usuario.CodigoResetarSenhaExpiraEm >= DateTime.Now))
        {
            Notificator.Handle("Código inválido ou expirado!");
            return;
        }

        if (!dto.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
            return;
        }

        usuario.Senha = _passwordHasher.HashPassword(usuario, dto.Senha);
        usuario.CodigoResetarSenha = null;
        usuario.CodigoResetarSenhaExpiraEm = null;

        _usuarioRepository.Alterar(usuario);
        if (!await _usuarioRepository.UnitOfWork.Commit())
        {
            Notificator.Handle("Não foi possível alterar a senha");
        }
    }

    public async Task<string> CreateTokenUsuario(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Settings.Secret);
        var claimsIdentity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim("TipoUsuario", ETipoUsuario.Usuario.ToDescriptionString()),
            new Claim("Administrador", ETipoUsuario.Usuario.ToDescriptionString()),
            new Claim("Lojista", ETipoUsuario.Usuario.ToDescriptionString()),
            new Claim("Usuario", ETipoUsuario.Usuario.ToDescriptionString()),
            new Claim("GrupoAcesso", "GrupoAcesso")
        });

        await AdicionarPermissoes(usuario, claimsIdentity);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return await Task.FromResult(tokenHandler.WriteToken(token));
    }
    
    private async Task AdicionarPermissoes(Usuario usuario, ClaimsIdentity claimsIdentity)
    {
        if (!usuario.GrupoAcessos.Any())
        {
            return;
        }

        var gruposIds = usuario
            .GrupoAcessos
            .Select(g => g.Id)
            .ToList();

        var grupos = await _grupoAcessoRepository.ObterTodos();
        var gruposFiltrados = grupos.Where(c => gruposIds.Contains(c.Id));

        var permissoes = MapPermissoes(gruposFiltrados.SelectMany(c => c.Permissoes)).Select(p => p.ToString());
        claimsIdentity.AddClaim(new Claim("permissoes", JsonConvert.SerializeObject(permissoes), JsonClaimValueTypes.JsonArray)); 
    }

    private static IEnumerable<PermissaoClaim> MapPermissoes(IEnumerable<GrupoAcessoPermissao> permissoes)
    {
        return permissoes
            .GroupBy(c => c.PermissaoId)
            .Select(grupo =>
            {
                var tipos = grupo
                    .SelectMany(gap => gap.Tipo.ToCharArray().Select(c => c.ToString()))
                    .Distinct();
                
                return new PermissaoClaim
                {
                    Nome = grupo.First().Permissao.Nome,
                    Tipo = string.Join("", tipos)
                };
            })
            .ToList();
    }
}