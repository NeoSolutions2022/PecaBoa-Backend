using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Usuario;

public class CategoriaVeiculoController : MainController
{
    private readonly ICategoriaVeiculoService _categoriaVeiculoService;
    
    protected CategoriaVeiculoController(INotificator notificator, ICategoriaVeiculoService categoriaVeiculoService) : base(notificator)
    {
        _categoriaVeiculoService = categoriaVeiculoService;
    }
    
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Listar Categoria veiculo.", Tags = new [] { "Usuario - Categoria Veiculo" })]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<List<CategoriaVeiculoDto>> Listar()
    {
        return await _categoriaVeiculoService.Listar();
    }

}