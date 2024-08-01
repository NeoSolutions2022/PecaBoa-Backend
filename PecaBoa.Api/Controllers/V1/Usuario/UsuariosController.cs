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

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter um Usuario por Id.", Tags = new [] { "Usuario - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        return OkResponse(usuario);
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
    
    [HttpPost("alterar-senha-sem-email")]
    [SwaggerOperation(Summary = "alterar a senha sem envio de Email.", Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AlterarSenhaSemEnvioEmail(AlterarSenhaUsuarioSemEnvioEmailDto dto)
    {
        await _usuarioService.AlterarSenhaSemEnvioEmail(dto);
        return OkResponse();
    }
    
    [HttpPatch("alterar-foto")]
    [SwaggerOperation(Summary = "Alterar a foto do Usuario.",
        Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AlterarFoto([FromForm] AlterarFotoUsuarioDto dto)
    {
        await _usuarioService.AlterarFoto(dto);
        return NoContentResponse();
    }

    [HttpPatch("remover-foto")]
    [SwaggerOperation(Summary = "Remover a foto do Usuario.",
        Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoverFoto()
    {
        await _usuarioService.RemoverFoto();
        return NoContentResponse();
    }
    
    [HttpPatch("Desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar um Usuario.", Tags = new [] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _usuarioService.Desativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch("reativar/{id}")]
    [SwaggerOperation(Summary = "Reativar um Usuario.", Tags = new [] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _usuarioService.Reativar(id);
        return NoContentResponse();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover um Usuario.", Tags = new[] { "Usuario - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _usuarioService.Remover(id);
        return NoContentResponse();
    }
}