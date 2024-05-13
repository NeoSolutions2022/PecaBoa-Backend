using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    void Adicionar(Usuario usuario);
    void Alterar(Usuario usuario);
    Task<Usuario?> ObterPorId(int id);
    Task<Usuario?> ObterPorEmail(string email);
    Task<Usuario?> ObterPorCpf(string cpf);
    void Remover(Usuario usuario);
    Task<IResultadoPaginado<Usuario>> Buscar(IBuscaPaginada<Usuario> filtro);
}