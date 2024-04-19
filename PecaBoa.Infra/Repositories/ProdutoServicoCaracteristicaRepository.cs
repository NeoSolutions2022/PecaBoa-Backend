using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class ProdutoServicoCaracteristicaRepository : Repository<ProdutoServicoCaracteristica>,
    IProdutoServicoCaracteristicaRepository
{
    public ProdutoServicoCaracteristicaRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(List<ProdutoServicoCaracteristica> produtoServicoCaracteristica)
    {
        Context.ProdutoServicoCaracteristicas.AddRange(produtoServicoCaracteristica);
    }

    public void Alterar(ProdutoServicoCaracteristica produtoServicoCaracteristica)
    {
        Context.ProdutoServicoCaracteristicas.UpdateRange(produtoServicoCaracteristica);
    }

    public async Task<ProdutoServicoCaracteristica?> ObterPorId(int id)
    {
        return await Context.ProdutoServicoCaracteristicas
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<ProdutoServicoCaracteristica>?> ObterTodos(int id)
    {
        return await Context.ProdutoServicoCaracteristicas.Where(c => c.ProdutoServico.Id == id)
            .ToListAsync();
    }

    public void Remover(ProdutoServicoCaracteristica produtoServicoCaracteristica)
    {
        Context.ProdutoServicoCaracteristicas.RemoveRange(produtoServicoCaracteristica);
    }
}