using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Cliente cliente)
    {
        Context.Clientes.Add(cliente);
    }

    public void Alterar(Cliente cliente)
    {
        Context.Clientes.Update(cliente);
    }

    public async Task<Cliente?> ObterPorId(int id)
    {
        return await Context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> ObterPorEmail(string email)
    {
        return await Context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Cliente?> ObterPorCpf(string cpf)
    {
        return await Context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public void Remover(Cliente cliente)
    {
        Context.Clientes.Remove(cliente);
    }

    public async Task<IResultadoPaginado<Cliente>> Buscar(IBuscaPaginada<Cliente> filtro)
    {
        var query = Context.Clientes.AsQueryable();
        return await base.Buscar(query, filtro);
    }
}