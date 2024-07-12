using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class ModeloRepository : Repository<Modelo>, IModeloRepository
{
    public ModeloRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Modelo>> Listar() => await Context.Modelos.ToListAsync();
    public async Task<List<Modelo>> ListarPorMarcaId(int marcaId)
    {
        return await Context.Modelos.Where(c => c.MarcaId == marcaId).ToListAsync();
    }
}