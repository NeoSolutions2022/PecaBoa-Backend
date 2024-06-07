using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class CondicaoPecaRepository : Repository<CondicaoPeca>, ICondicaoPecaRepository
{
    public CondicaoPecaRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<CondicaoPeca>> Listar() => await Context.CondicaoPecas.ToListAsync();
}