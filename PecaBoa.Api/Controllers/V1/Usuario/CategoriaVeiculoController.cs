using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Route("v{version:apiVersion}/Usuario/[controller]")]
public class CategoriaVeiculoController : MainController
{
    private readonly ICategoriaVeiculoService _categoriaVeiculoService;
    
    public CategoriaVeiculoController(INotificator notificator, ICategoriaVeiculoService categoriaVeiculoService) : base(notificator)
    {
        _categoriaVeiculoService = categoriaVeiculoService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Categoria veiculo.", Tags = new [] { "Usuario - Categoria Veiculo" })]
    [ProducesResponseType(typeof(CategoriaVeiculoDto),StatusCodes.Status200OK)]
    public async Task<List<CategoriaVeiculoDto>> Listar()
    {
        return await _categoriaVeiculoService.Listar();
    }

}