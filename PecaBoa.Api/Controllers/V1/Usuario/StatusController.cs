using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class StatusController : BaseController
{
    private readonly IStatusService _statusService;
    
    public StatusController(INotificator notificator, IStatusService statusService) : base(notificator)
    {
        _statusService = statusService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Status.", Tags = new [] { "Usuario - Status" })]
    [ProducesResponseType(typeof(StatusDto),StatusCodes.Status200OK)]
    public async Task<List<StatusDto>> Listar()
    {
        return await _statusService.Listar();
    }
}