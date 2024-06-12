using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

public class CondicaoPecaController : MainController
{
    private readonly ICondicaoPecaService _condicaoPecaService;
    
    public CondicaoPecaController(INotificator notificator, ICondicaoPecaService condicaoPecaService) : base(notificator)
    {
        _condicaoPecaService = condicaoPecaService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar CondicaoPeca.", Tags = new [] { "Usuario - Condição Peça" })]
    [ProducesResponseType(typeof(StatusDto),StatusCodes.Status200OK)]
    public async Task<List<CondicaoPecaDto>> Listar()
    {
        return await _condicaoPecaService.Listar();
    }
}