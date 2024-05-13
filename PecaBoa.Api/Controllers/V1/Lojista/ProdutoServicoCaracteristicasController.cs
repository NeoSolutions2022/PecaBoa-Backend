using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[Route("v{version:apiVersion}/Lojista/[controller]")]
public class PedidoCaracteristicasController : MainController
{
    private readonly IPedidoCaracteristicaService _caracteristicaService;
    public PedidoCaracteristicasController(INotificator notificator, IPedidoCaracteristicaService caracteristicaService) : base(notificator)
    {
        _caracteristicaService = caracteristicaService;
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter Caracteristica Produto/Serviço - Lojista.", Tags = new[] { "Lojista - Produto-Serviço" })]
    [ProducesResponseType(typeof(PedidoCaracteristicaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var Pedido = await _caracteristicaService.ObterPorId(id);
        return OkResponse(Pedido);
    }

    [HttpGet("PedidoId/{produtoId}")]
    [SwaggerOperation(Summary = "Buscar Caracteristica Produto/Serviço - Lojista.",
        Tags = new[] { "Lojista - Produto-Serviço" })]
    [ProducesResponseType(typeof(List<PedidoCaracteristicaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterTodos(int produtoId)
    {
        var Pedido = await _caracteristicaService.ObterPorTodos(produtoId);
        return OkResponse(Pedido);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cadastrar Caracteristica Produto/Serviço - Lojista.",
        Tags = new[] { "Lojista - Produto-Serviço" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(typeof(PedidoCaracteristicaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Cadastrar([FromForm] List<AdicionarPedidoCaracteristicaDto> dto)
    {
        var Pedido = await _caracteristicaService.Adicionar(dto);
        return OkResponse(Pedido);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Alterar Caracteristica Produto/Serviço - Lojista.",
        Tags = new[] { "Lojista - Produto-Serviço" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(typeof(PedidoCaracteristicaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Alterar(int id, AlterarPedidoCaracteristicaDto dto)
    {
        var Pedido = await _caracteristicaService.Alterar(id, dto);
        return OkResponse(Pedido);
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover uma Caracteristica.", Tags = new[] { "Lojista - Produto-Serviço" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _caracteristicaService.Remover(id);
        return NoContentResponse();
    }
}