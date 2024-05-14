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

    public void Adicionar(Pedido pedido)
    {
        Context.Pedidos.Add(pedido);
    }

    public void Alterar(Pedido pedido)
    {
        Context.Pedidos.Update(pedido);
    }

    public async Task<Pedido?> ObterPorId(int id)
    {
        return await Context.Pedidos
            .Include(c => c.Usuario)
            .Include(c => c.PedidoCaracteristicas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IResultadoPaginado<Pedido>> Buscar(IBuscaPaginada<Pedido> filtro)
    {
        var query = Context.Pedidos
            .Include(c => c.Usuario)
            .Include(c => c.PedidoCaracteristicas)
            .AsQueryable();
        return await base.Buscar(query, filtro);
    }

    public void Remover(Pedido pedido)
    {
        Context.PedidoCaracteristicas.RemoveRange(pedido.PedidoCaracteristicas);
        Context.Pedidos.Remove(pedido);
    }
}