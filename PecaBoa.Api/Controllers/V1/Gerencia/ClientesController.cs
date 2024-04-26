using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Gerencia;

[Route("v{version:apiVersion}/Gerencia/[controller]")]
public class UsuariosController : MainController
{
    private readonly IUsuarioService _usuarioService;
    
    public UsuariosController(INotificator notificator, IUsuarioService usuarioService) : base(notificator)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Listagem de Usuarios", Tags = new[] { "Gerencia - Usuario" })]
    [ProducesResponseType(typeof(PagedDto<UsuarioDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]

    public async Task<IActionResult> Buscar([FromQuery] BuscarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Buscar(dto);
        return OkResponse(usuario);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter um Usuario por Id.", Tags = new [] { "Gerencia - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        return OkResponse(usuario);
    }
    
    [HttpGet("email/{email}")]
    [SwaggerOperation(Summary = "Obter um Usuario por Email.", Tags = new [] { "Gerencia - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorEmail(string email)
    {
        var usuario = await _usuarioService.ObterPorEmail(email);
        return OkResponse(usuario);
    }
    
    [HttpGet("cpf/{cpf}")]
    [SwaggerOperation(Summary = "Obter um Usuario por Cpf.", Tags = new [] { "Gerencia - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorCpf(string cpf)
    {
        var usuario = await _usuarioService.ObterPorCpf(cpf);
        return OkResponse(usuario);
    }

    [HttpPatch("ativar/{id}")]
    [SwaggerOperation(Summary = "Desativar um Usuario.", Tags = new [] { "Gerencia - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _usuarioService.Desativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch("reativar/{id}")]
    [SwaggerOperation(Summary = "Reativar um Usuario.", Tags = new [] { "Gerencia - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _usuarioService.Reativar(id);
        return NoContentResponse();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover um Usuario.", Tags = new[] { "Gerencia - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _usuarioService.Remover(id);
        return NoContentResponse();
    }
}