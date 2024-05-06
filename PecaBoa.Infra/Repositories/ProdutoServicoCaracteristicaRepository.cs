using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class PedidoCaracteristicaRepository : Repository<PedidoCaracteristica>,
    IPedidoCaracteristicaRepository
{
    public PedidoCaracteristicaRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(List<PedidoCaracteristica> PedidoCaracteristica)
    {
        Context.PedidoCaracteristicas.AddRange(PedidoCaracteristica);
    }

    public void Alterar(PedidoCaracteristica PedidoCaracteristica)
    {
        Context.PedidoCaracteristicas.UpdateRange(PedidoCaracteristica);
    }

    public async Task<PedidoCaracteristica?> ObterPorId(int id)
    {
        return await Context.PedidoCaracteristicas
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<PedidoCaracteristica>?> ObterTodos(int id)
    {
        return await Context.PedidoCaracteristicas.Where(c => c.Pedido.Id == id)
            .ToListAsync();
    }

    public void Remover(PedidoCaracteristica PedidoCaracteristica)
    {
        Context.PedidoCaracteristicas.RemoveRange(PedidoCaracteristica);
    }
}