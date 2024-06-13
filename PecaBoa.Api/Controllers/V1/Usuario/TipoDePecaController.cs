using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

public class TipoDePecaController : MainController
{
    private readonly ITipoDePecaService _tipoDePecaService;
    
    public TipoDePecaController(INotificator notificator, ITipoDePecaService tipoDePecaService) : base(notificator)
    {
        _tipoDePecaService = tipoDePecaService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Tipo Peça.", Tags = new [] { "Usuario - Tipo Peça" })]
    [ProducesResponseType(typeof(TipoDePecaDto),StatusCodes.Status200OK)]
    public async Task<List<TipoDePecaDto>> Listar()
    {
        return await _tipoDePecaService.Listar();
    }
}