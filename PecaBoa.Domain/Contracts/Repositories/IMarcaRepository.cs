using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IMarcaRepository : IRepository<Marca>
{
    Task<List<Marca>> Listar();
}