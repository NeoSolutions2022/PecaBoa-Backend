using PecaBoa.Application.Dtos.V1.Administrador.TipoDePeca;

namespace PecaBoa.Application.Contracts;

public interface ITipoDePecaService
{
    Task<List<TipoDePecaDto>> Listar();
}