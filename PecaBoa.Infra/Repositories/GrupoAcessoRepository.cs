using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class GrupoAcessoRepository : Repository<GrupoAcesso>, IGrupoAcessoRepository
{
    public GrupoAcessoRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public async Task<GrupoAcesso?> ObterPorId(int id)
    {
        return await Context.GruposAcesso
            .Include(ga => ga.Permissoes)
            .ThenInclude(gap => gap.Permissao)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<List<GrupoAcesso>> ObterPorIds(List<int> ids)
    {
        return await Context.GruposAcesso
            .Include(ga => ga.Permissoes)
            .ThenInclude(gap => gap.Permissao)
            .Where(c => ids.Equals(c.Id)).ToListAsync();
    }

    public async Task<List<GrupoAcesso>> ObterTodos()
    {
        return await Context.GruposAcesso
            .Include(ga => ga.Permissoes)
            .ThenInclude(gap => gap.Permissao)
            .AsNoTracking()
            .ToListAsync();
    }

    public void Cadastrar(GrupoAcesso grupoAcesso)
    {
        Context.GruposAcesso.Add(grupoAcesso);
    }

    public void Editar(GrupoAcesso grupoAcesso)
    {
        Context.GruposAcesso.Update(grupoAcesso);
    }
}