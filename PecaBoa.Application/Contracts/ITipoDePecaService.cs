using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;

namespace PecaBoa.Application.Contracts;

public interface ITipoDePecaService
{
    Task<List<TipoDePecaDto>> Listar();
}