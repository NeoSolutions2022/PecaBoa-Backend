using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class LojistaCartaoDeCreditoRepository : Repository<LojistaCartaoDeCredito>, ILojistaCartaoDeCreditoRepository
{
    public LojistaCartaoDeCreditoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<LojistaCartaoDeCredito?> GetById(int id)
    {
        return await Context.LojistaCartoesDeCredito.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<LojistaCartaoDeCredito>> GetAll()
    {
        return await Context.LojistaCartoesDeCredito.ToListAsync();
    }

    public void Create(LojistaCartaoDeCredito user)
    {
        Context.LojistaCartoesDeCredito.Add(user);
    }

    public void Update(LojistaCartaoDeCredito user)
    {
        Context.LojistaCartoesDeCredito.Update(user);
    }

    public void Remove(LojistaCartaoDeCredito user)
    {
        Context.LojistaCartoesDeCredito.Remove(user);
    }
}