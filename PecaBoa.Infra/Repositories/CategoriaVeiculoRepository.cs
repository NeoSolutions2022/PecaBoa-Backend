using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class CategoriaVeiculoRepository : Repository<CategoriaVeiculo>, ICategoriaVeiculoRepository
{
    public CategoriaVeiculoRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<CategoriaVeiculo>> Listar() => await Context.CategoriaVeiculos.ToListAsync();
}