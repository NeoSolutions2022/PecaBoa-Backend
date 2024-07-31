using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class AdministradorRepository : Repository<Administrador>, IAdministradorRepository
{
    public AdministradorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Administrador administrador)
    {
        Context.Administradores.Add(administrador);
    }

    public void Alterar(Administrador administrador)
    {
        Context.Administradores.Update(administrador);
    }

    public void Remover(Administrador administrador)
    {
        Context.Administradores.Remove(administrador);
    }

    public async Task<Administrador?> ObterPorId(int id)
    {
        return await Context.Administradores.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Administrador?> ObterPorEmail(string email)
    {
        return await Context.Administradores.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<IResultadoPaginado<Administrador>> Buscar(IBuscaPaginada<Administrador> filtro)
    {
        var query = Context.Administradores.AsQueryable();
        return await base.Buscar(query, filtro);
    }
}