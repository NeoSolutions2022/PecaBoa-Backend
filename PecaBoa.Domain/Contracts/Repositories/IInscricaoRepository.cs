using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IInscricaoRepository : IRepository<Inscricao>
{
    void Adicionar(Inscricao inscricao);
    void Alterar(Inscricao inscricao);
    Task<Inscricao?> ObterPorId(int id);
    void Remover(Inscricao inscricao);
}