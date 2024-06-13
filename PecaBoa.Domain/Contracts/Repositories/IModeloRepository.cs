using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IModeloRepository
{
    Task<List<Modelo>> Listar();
}