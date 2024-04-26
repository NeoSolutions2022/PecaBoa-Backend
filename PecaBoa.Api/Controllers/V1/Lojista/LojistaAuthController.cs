using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[AllowAnonymous]
[Route("v{version:apiVersion}/Lojista/[controller]")]
public class LojistaAuthController : BaseController
{
    private readonly ILojistaAuthService _lojistaAuthService;

    public LojistaAuthController(INotificator notificator, ILojistaAuthService lojistaAuthService) :
        base(notificator)
    {
        _lojistaAuthService = lojistaAuthService;
    }

    [HttpPost("Login-Lojista")]
    [SwaggerOperation(Summary = "Login - Lojista.", Tags = new[] { "Usuario - Lojista - Autenticação" })]
    [ProducesResponseType(typeof(UsuarioAutenticadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> LoginLojista([FromBody] LoginDto loginLojista)
    {
        var token = await _lojistaAuthService.Login(loginLojista);
        return token != null ? OkResponse(token) : Unauthorized(new[] { "Usuário e/ou senha incorretos" });
    }

    [HttpPost("verificar-codigo")]
    [SwaggerOperation(Summary = "Verifica o código para resetar a senha.",
        Tags = new[] { "Usuario - Lojista - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> VerificarCodigo([FromBody] VerificarCodigoResetarSenhaLojistaDto dto)
    {
        await _lojistaAuthService.VerificarCodigo(dto);
        return OkResponse();
    }

    [HttpPost("recuperar-senha")]
    [SwaggerOperation(Summary = "Enviar email para recuperar a senha.",
        Tags = new[] { "Usuario - Lojista - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RecuperarSenha([FromBody] RecuperarSenhaLojistaDto dto)
    {
        await _lojistaAuthService.RecuperarSenha(dto);
        return OkResponse();
    }

    [HttpPost("alterar-senha")]
    [SwaggerOperation(Summary = "Alterar a senha do usuario.", Tags = new[] { "Usuario - Lojista - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaLojistaDto dto)
    {
        await _lojistaAuthService.AlterarSenha(dto);
        return OkResponse();
    }
}