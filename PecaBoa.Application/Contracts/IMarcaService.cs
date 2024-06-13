using PecaBoa.Application.Dtos.V1.Usuario.Marca;

namespace PecaBoa.Application.Contracts;

public interface IMarcaService
{
    Task<List<MarcaDto>> Listar();
}