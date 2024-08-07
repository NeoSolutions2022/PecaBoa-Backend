using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public PedidoRepository(ApplicationDbContext context) : base(context)
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
            .Include(c => c.Orcamentos)
            .ThenInclude(c => c.Lojista)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IResultadoPaginado<Pedido>> Buscar(IBuscaPaginada<Pedido> filtro)
    {
        var query = Context.Pedidos
            .Where(c => c.Orcamentos.Count < 10)
            .Include(c => c.Usuario)
            .Include(c => c.Orcamentos)
            .AsQueryable();
        return await base.Buscar(query, filtro);
    }

    public async Task<List<Pedido>> BuscarPedidoUsuario(int id)
    {
        return await Context.Pedidos
            .Where(c => c.UsuarioId == id)
            .Include(c => c.Orcamentos)
            .Include(c => c.Usuario)
            .ToListAsync();
    }

    public async Task<List<Pedido>> ObterPedidosParaInativar()
    {
        return await Context.Pedidos
            .Where(c => c.DataFim <= DateTime.UtcNow && !c.Desativado)
            .ToListAsync();
    }

    public void Remover(Pedido pedido)
    {
        Context.Pedidos.Remove(pedido);
    }
}