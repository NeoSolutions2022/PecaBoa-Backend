using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[AllowAnonymous]
[Route("v{version:apiVersion}/Usuario/[controller]")]
public class UsuariosAuthController : BaseController
{
    private readonly IUsuarioAuthService _usuarioAuthService;

    public UsuariosAuthController(INotificator notificator, IUsuarioAuthService usuarioAuthService) : base(notificator)
    {
        _usuarioAuthService = usuarioAuthService;
    }

    [HttpPost("Login-Usuario")]
    [SwaggerOperation(Summary = "Login - Usuario.", Tags = new[] { "Usuario - Usuario - Autenticação" })]
    [ProducesResponseType(typeof(UsuarioAutenticadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> LoginUsuario([FromBody] LoginDto loginUsuario)
    {
        var token = await _usuarioAuthService.Login(loginUsuario);
        return token != null ? OkResponse(token) : Unauthorized(new[] { "Usuário e/ou senha incorretos" });
    }

    [HttpPost("verificar-codigo")]
    [SwaggerOperation(Summary = "Verifica o código para resetar a senha.",
        Tags = new[] { "Usuario - Usuario - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> VerificarCodigo([FromBody] VerificarCodigoResetarSenhaUsuarioDto dto)
    {
        await _usuarioAuthService.VerificarCodigo(dto);
        return OkResponse();
    }

    [HttpPost("recuperar-senha")]
    [SwaggerOperation(Summary = "Enviar email para recuperar a senha.",
        Tags = new[] { "Usuario - Usuario - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RecuperarSenha([FromBody] RecuperarSenhaUsuarioDto dto)
    {
        await _usuarioAuthService.RecuperarSenha(dto);
        return OkResponse();
    }

    [HttpPost("alterar-senha")]
    [SwaggerOperation(Summary = "Alterar a senha do usuario.", Tags = new[] { "Usuario - Usuario - Autenticação" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaUsuarioDto dto)
    {
        await _usuarioAuthService.AlterarSenha(dto);
        return OkResponse();
    }
}