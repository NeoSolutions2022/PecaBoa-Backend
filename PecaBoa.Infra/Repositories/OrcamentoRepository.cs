using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class OrcamentoRepository : Repository<Orcamento>, IOrcamentoRepository
{
    public OrcamentoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Orcamento orcamento)
    {
        Context.Orcamentos.Add(orcamento);
    }

    public void Alterar(Orcamento orcamento)
    {
        Context.Orcamentos.Update(orcamento);
    }

    public async Task<Orcamento?> ObterPorId(int id)
    {
        return await Context.Orcamentos
            .Include(c => c.Pedido)
            .Include(c => c.Lojista)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IResultadoPaginado<Orcamento>> Buscar(IBuscaPaginada<Orcamento> filtro)
    {
        var query = Context.Orcamentos
            .Include(c => c.Pedido)
            .Include(c => c.Lojista)
            .AsQueryable();

        return await base.Buscar(query, filtro);
    }

    public async Task<List<Orcamento>> BuscarOrcamentosLojista(int id)
    {
        return await Context.Orcamentos
            .Where(c => c.LojistaId == id)
            .Include(c => c.Pedido)
            .Include(c => c.Lojista)
            .ToListAsync();
    }

    public void Remover(Orcamento orcamento)
    {
        Context.Orcamentos.Remove(orcamento);
    }
}