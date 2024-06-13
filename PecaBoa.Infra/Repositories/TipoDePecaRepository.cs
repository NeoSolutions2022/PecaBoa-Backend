using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class TipoDePecaRepository : Repository<TipoDePeca>, ITipoDePecaRepository
{
    public TipoDePecaRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<TipoDePeca>> Listar() => await Context.TipoDePecas.ToListAsync();
}