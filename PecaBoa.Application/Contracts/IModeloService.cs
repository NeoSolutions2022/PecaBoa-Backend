using PecaBoa.Application.Dtos.V1.Usuario.Modelo;

namespace PecaBoa.Application.Contracts;

public interface IModeloService
{
    Task<List<ModeloDto>> Listar();
}