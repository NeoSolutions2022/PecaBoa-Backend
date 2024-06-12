using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Modelo;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class ModeloController : MainController
{
    private readonly IModeloService _modeloService;
    
    public ModeloController(INotificator notificator, IModeloService modeloService) : base(notificator)
    {
        _modeloService = modeloService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Modelos.", Tags = new [] { "Usuario - Modelos" })]
    [ProducesResponseType(typeof(ModeloDto),StatusCodes.Status200OK)]
    public async Task<List<ModeloDto>> Listar()
    {
        return await _modeloService.Listar();
    }
}