using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Fornecedor fornecedor)
    {
        Context.Fornecedores.Add(fornecedor);
    }

    public void Alterar(Fornecedor fornecedor)
    {
        Context.Fornecedores.Update(fornecedor);
    }

    public async Task<Fornecedor?> ObterPorId(int id)
    {
        return await Context.Fornecedores
            .Include(c => c.ProdutoServicos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Fornecedor?> ObterPorEmail(string email)
    {
        return await Context.Fornecedores.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Fornecedor?> ObterPorCpf(string cpf)
    {
        return await Context.Fornecedores.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task<Fornecedor?> ObterPorCnpj(string cnpj)
    {
        return await Context.Fornecedores.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
    }

    public void Remover(Fornecedor fornecedor)
    {
        Context.Fornecedores.Remove(fornecedor);
    }

    public async Task<IResultadoPaginado<Fornecedor>> Buscar(IBuscaPaginada<Fornecedor> filtro)
    {
        var query = Context.Fornecedores
            .Include(c => c.ProdutoServicos)
            .AsQueryable();
        return await base.Buscar(query, filtro);
    }
}