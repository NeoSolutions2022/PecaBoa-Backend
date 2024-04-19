using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Fornecedor;
using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Fornecedor;

[Route("v{version:apiVersion}/Fornecedor/[controller]")]
public class FornecedoresCadastroController : BaseController
{
    private readonly IFornecedorService _fornecedorService;
    public FornecedoresCadastroController(INotificator notificator, IFornecedorService fornecedorService) : base(notificator)
    {
        _fornecedorService = fornecedorService;
    }
    
    [AllowAnonymous]
    [HttpPost]
    [SwaggerOperation(Summary = "Cadastro de um Fornecedor.", Tags = new [] { "Usuario - Fornecedor" })]
    [ProducesResponseType(typeof(FornecedorDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarFornecedorDto dto)
    {
        var fornecedor = await _fornecedorService.Cadastrar(dto);
        return CreatedResponse("", fornecedor);
    }
}