using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface ITipoDePecaRepository : IRepository<TipoDePeca>
{
    Task<List<TipoDePeca>> Listar();
}