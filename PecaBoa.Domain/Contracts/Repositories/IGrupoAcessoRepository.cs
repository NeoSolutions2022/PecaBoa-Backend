using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IGrupoAcessoRepository : IRepository<GrupoAcesso>
{
    Task<GrupoAcesso?> ObterPorId(int id);
    Task<List<GrupoAcesso>> ObterTodos();
    Task<List<GrupoAcesso>> ObterPorIds(List<int> ids);
    void Cadastrar(GrupoAcesso grupoAcesso);
    void Editar(GrupoAcesso grupoAcesso);
}