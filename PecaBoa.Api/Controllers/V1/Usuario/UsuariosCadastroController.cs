using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class UsuariosCadastroController : BaseController
{
    private readonly IUsuarioService _usuarioService;
    
    public UsuariosCadastroController(INotificator notificator, IUsuarioService usuarioService) : base(notificator)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Cadastro de um Usuario.", Tags = new [] { "Usuario - Usuario" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Cadastrar(dto);
        return CreatedResponse("", usuario);
    }
}