using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class PedidoController : Lojista.MainController
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(INotificator notificator, IPedidoService pedidoService) :
        base(notificator)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter Pedido - Usuario.", Tags = new[] { "Usuario - Pedido" })]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var pedido = await _pedidoService.ObterPorId(id);
        return OkResponse(pedido);
    }

    [AllowAnonymous]
    [HttpGet]
    [SwaggerOperation(Summary = "Buscar Pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ProducesResponseType(typeof(PagedDto<PedidoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Buscar([FromQuery] BuscarPedidoDto dto)
    {
        var pedido = await _pedidoService.Buscar(dto);
        return OkResponse(pedido);
    }
    
    [HttpGet("pedidos-do-usuario")]
    [SwaggerOperation(Summary = "Listar Pedidos do usuario - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ProducesResponseType(typeof(List<PedidoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ListarPedidosUsuario()
    {
        var pedido = await _pedidoService.BuscarPedidosUsuario();
        return OkResponse(pedido);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cadastrar Pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarPedidoDto dto)
    {
        var pedido = await _pedidoService.Adicionar(dto);
        return OkResponse(pedido);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Alterar Pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarPedidoDto dto)
    {
        var pedido = await _pedidoService.Alterar(id, dto);
        return OkResponse(pedido);
    }

    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar Pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _pedidoService.Desativar(id);
        return NoContentResponse();
    }

    [HttpPatch("reativar/{id}")]
    [SwaggerOperation(Summary = "Reativar Pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _pedidoService.Reativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch("renovar/{id}")]
    [SwaggerOperation(Summary = "Renovar Pedido - Usuario.", Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RenovarPedido(int id)
    {
        await _pedidoService.RenovarPedido(id);
        return NoContentResponse();
    }

    [HttpPatch("alterar-foto")]
    [SwaggerOperation(Summary = "Alterar a foto de um pedido ou serviço - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AlterarFoto([FromForm] AlterarFotoPedidoDto dto)
    {
        await _pedidoService.AlterarFoto(dto);
        return NoContentResponse();
    }

    [HttpPatch("remover-foto")]
    [SwaggerOperation(Summary = "Remover a foto de um pedido - Usuario.",
        Tags = new[] { "Usuario - Pedido" })]
    [ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoverFoto([FromForm] RemoverFotosPedidoDto dto)
    {
        await _pedidoService.RemoverFoto(dto);
        return NoContentResponse();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover um pedido.", Tags = new[] { "Usuario - Pedido" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _pedidoService.Remover(id);
        return NoContentResponse();
    }
}