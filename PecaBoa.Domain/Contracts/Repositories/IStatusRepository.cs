using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IStatusRepository : IRepository<Status>
{
    Task<List<Status>> Listar();
}