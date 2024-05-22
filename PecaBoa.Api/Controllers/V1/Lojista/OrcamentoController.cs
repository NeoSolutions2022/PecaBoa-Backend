using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Dtos.V1.Orcamento;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[Route("v{version:apiVersion}/Lojista/[controller]")]
public class OrcamentoController : MainController
{
    private readonly IOrcamentoService _orcamentoService;

    public OrcamentoController(INotificator notificator, IOrcamentoService orcamentoService) :
        base(notificator)
    {
        _orcamentoService = orcamentoService;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter Orcamento - Lojista.", Tags = new[] { "Lojista - Orcamento" })]
    [ProducesResponseType(typeof(OrcamentoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var orcamento = await _orcamentoService.ObterPorId(id);
        return OkResponse(orcamento);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Buscar Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ProducesResponseType(typeof(PagedDto<OrcamentoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Buscar([FromQuery] BuscarOrcamentoDto dto)
    {
        var orcamento = await _orcamentoService.Buscar(dto);
        return OkResponse(orcamento);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cadastrar Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(typeof(OrcamentoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarOrcamentoDto dto)
    {
        var orcamento = await _orcamentoService.Adicionar(dto);
        return OkResponse(orcamento);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Alterar Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(typeof(OrcamentoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarOrcamentoDto dto)
    {
        var orcamento = await _orcamentoService.Alterar(id, dto);
        return OkResponse(orcamento);
    }

    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _orcamentoService.Desativar(id);
        return NoContentResponse();
    }

    [HttpPatch("reativar/{id}")]
    [SwaggerOperation(Summary = "Reativar Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _orcamentoService.Reativar(id);
        return NoContentResponse();
    }

    [HttpPatch("alterar-foto")]
    [SwaggerOperation(Summary = "Alterar a foto de um Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AlterarFoto([FromForm] AlterarFotoOrcamentoDto dto)
    {
        await _orcamentoService.AlterarFoto(dto);
        return NoContentResponse();
    }

    [HttpPatch("remover-foto")]
    [SwaggerOperation(Summary = "Remover a foto de um Orcamento - Lojista.",
        Tags = new[] { "Lojista - Orcamento" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoverFoto([FromForm] RemoverFotosOrcamentoDto dto)
    {
        await _orcamentoService.RemoverFoto(dto);
        return NoContentResponse();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover um Orcamento.", Tags = new[] { "Lojista - Orcamento" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _orcamentoService.Remover(id);
        return NoContentResponse();
    }
}