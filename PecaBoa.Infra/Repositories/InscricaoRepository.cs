using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class InscricaoRepository : Repository<Inscricao>, IInscricaoRepository
{
    public InscricaoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Inscricao inscricao)
    {
        Context.Inscricoes.Add(inscricao);
    }

    public void Alterar(Inscricao inscricao)
    {
        Context.Inscricoes.Update(inscricao);
    }

    public async Task<Inscricao?> ObterPorId(int id)
    {
        return await Context.Inscricoes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Remover(Inscricao inscricao)
    {
        Context.Inscricoes.Remove(inscricao);
    }
}