using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class UsuariosController : MainController
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(INotificator notificator, IUsuarioService usuarioService) : base(notificator)
    {
        _usuarioService = usuarioService;
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar um Usuario.", Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Alterar(id, dto);
        return OkResponse(usuario);
    }

    [HttpPost("{id}/alterar-senha")]
    [SwaggerOperation(Summary = "Enviar email para alterar a senha.", Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AlterarSenha(int id)
    {
        await _usuarioService.AlterarSenha(id);
        return OkResponse();
    }
}