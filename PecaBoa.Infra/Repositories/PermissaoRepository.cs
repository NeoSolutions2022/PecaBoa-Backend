using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
{
    public PermissaoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Permissao?> ObterPorId(int id)
    {
        return await Context.Permissoes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Cadastrar(Permissao permissao)
    {
        Context.Permissoes.Add(permissao);
    }

    public void Alterar(Permissao permissao)
    {
        Context.Permissoes.Update(permissao);
    }

    public void Deletar(Permissao permissao)
    {
        Context.Permissoes.Remove(permissao);
    }
}