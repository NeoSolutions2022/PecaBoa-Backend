using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class LojistaRepository : Repository<Lojista>, ILojistaRepository
{
    public LojistaRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Lojista lojista)
    {
        Context.Lojistas.Add(lojista);
    }

    public void Alterar(Lojista lojista)
    {
        Context.Lojistas.Update(lojista);
    }

    public async Task<Lojista?> ObterPorId(int id)
    {
        return await Context.Lojistas
            .Include(c => c.ProdutoServicos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Lojista?> ObterPorEmail(string email)
    {
        return await Context.Lojistas.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Lojista?> ObterPorCpf(string cpf)
    {
        return await Context.Lojistas.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task<Lojista?> ObterPorCnpj(string cnpj)
    {
        return await Context.Lojistas.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
    }

    public void Remover(Lojista lojista)
    {
        Context.Lojistas.Remove(lojista);
    }

    public async Task<IResultadoPaginado<Lojista>> Buscar(IBuscaPaginada<Lojista> filtro)
    {
        var query = Context.Lojistas
            .Include(c => c.ProdutoServicos)
            .AsQueryable();
        return await base.Buscar(query, filtro);
    }
}