using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public PedidoRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Pedido Pedido)
    {
        Context.Pedidos.Add(Pedido);
    }

    public void Alterar(Pedido Pedido)
    {
        Context.Pedidos.Update(Pedido);
    }

    public async Task<Pedido?> ObterPorId(int id)
    {
        return await Context.Pedidos
            .Include(c => c.Lojista)
            .Include(c => c.PedidoCaracteristicas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IResultadoPaginado<Pedido>> Buscar(IBuscaPaginada<Pedido> filtro)
    {
        var query = Context.Pedidos
            .Include(c => c.Lojista)
            .Include(c => c.PedidoCaracteristicas)
            .AsQueryable();
        return await base.Buscar(query, filtro);
    }

    public void Remover(Pedido Pedido)
    {
        Context.PedidoCaracteristicas.RemoveRange(Pedido.PedidoCaracteristicas);
        Context.Pedidos.Remove(Pedido);
    }
}