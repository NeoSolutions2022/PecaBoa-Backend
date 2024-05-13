using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[Route("v{version:apiVersion}/Lojista/[controller]")]
public class LojistaesCadastroController : BaseController
{
    private readonly ILojistaService _lojistaService;
    public LojistaesCadastroController(INotificator notificator, ILojistaService lojistaService) : base(notificator)
    {
        _lojistaService = lojistaService;
    }
    
    [AllowAnonymous]
    [HttpPost]
    [SwaggerOperation(Summary = "Cadastro de um Lojista.", Tags = new [] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarLojistaDto dto)
    {
        var lojista = await _lojistaService.Cadastrar(dto);
        return CreatedResponse("", lojista);
    }
}