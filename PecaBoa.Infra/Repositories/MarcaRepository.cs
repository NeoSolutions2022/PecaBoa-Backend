using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class MarcaRepository : Repository<Marca>, IMarcaRepository
{
    public MarcaRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Marca>> Listar() => await Context.Marcas.ToListAsync();
}