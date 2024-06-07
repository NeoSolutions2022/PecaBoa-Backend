using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface ICondicaoPecaRepository : IRepository<CondicaoPeca>
{
    Task<List<CondicaoPeca>> Listar();
}