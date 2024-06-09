using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Marca;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class MarcaController : MainController
{
    private readonly IMarcaService _marcaService;
    
    protected MarcaController(INotificator notificator, IMarcaService marcaService) : base(notificator)
    {
        _marcaService = marcaService;
    }
    
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Marcas.", Tags = new [] { "Usuario - Marcas" })]
    [ProducesResponseType(typeof(MarcaDto),StatusCodes.Status200OK)]
    public async Task<List<MarcaDto>> Listar()
    {
        return await _marcaService.Listar();
    }
}