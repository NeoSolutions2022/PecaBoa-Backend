using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Abstractions;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Usuario usuario)
    {
        Context.Usuarios.Add(usuario);
    }

    public void Alterar(Usuario usuario)
    {
        Context.Usuarios.Update(usuario);
    }

    public async Task<Usuario?> ObterPorId(int id)
    {
        return await Context.Usuarios
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Usuario?> ObterPorEmail(string email)
    {
        return await Context.Usuarios
            .FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Usuario?> ObterPorCpf(string cpf)
    {
        return await Context.Usuarios
            .FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public void Remover(Usuario usuario)
    {
        Context.Usuarios.Remove(usuario);
    }

    public async Task<IResultadoPaginado<Usuario>> Buscar(IBuscaPaginada<Usuario> filtro)
    {
        var query = Context.Usuarios.AsQueryable();
        return await base.Buscar(query, filtro);
    }
}