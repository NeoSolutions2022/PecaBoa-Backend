using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IModeloRepository
{
    Task<List<Modelo>> Listar();
    Task<List<Modelo>> ListarPorMarcaId(int marcaId);
}