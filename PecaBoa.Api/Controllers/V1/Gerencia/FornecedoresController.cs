using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Gerencia;

[Route("v{version:apiVersion}/Gerencia/[controller]")]
public class LojistaesController : MainController
{
    private readonly ILojistaService _lojistaService;

    public LojistaesController(INotificator notificator, ILojistaService lojistaService) : base(notificator)
    {
        _lojistaService = lojistaService;
    }
    
    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar um Lojista.", Tags = new[] { "Gerencia - Lojista" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _lojistaService.Desativar(id);
        return NoContentResponse();
    }

    [HttpPatch("reativar/{id}")]
    [SwaggerOperation(Summary = "Reativar um Lojista.", Tags = new[] { "Gerencia - Lojista" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _lojistaService.Reativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch("ativar-anuncio/{id}")]
    [SwaggerOperation(Summary = "Ativar anúncio para um Lojista.", Tags = new[] { "Gerencia - Lojista" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AtivarAnuncio(int id)
    {
        await _lojistaService.AtivarAnuncio(id);
        return NoContentResponse();
    }
    
    [HttpPatch("desativar-anuncio/{id}")]
    [SwaggerOperation(Summary = "Desativar anúncio para um Lojista.", Tags = new[] { "Gerencia - Lojista" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DesativarAnuncio(int id)
    {
        await _lojistaService.DesativarAnuncio(id);
        return NoContentResponse();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Remover um Lojista.", Tags = new[] { "Gerencia - Usuario" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remover(int id)
    {
        await _lojistaService.Remover(id);
        return NoContentResponse();
    }
}