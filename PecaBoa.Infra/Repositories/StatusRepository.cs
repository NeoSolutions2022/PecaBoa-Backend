using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class StatusRepository : Repository<Status>, IStatusRepository
{
    public StatusRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Status>> Listar() => await Context.Status.ToListAsync();
}