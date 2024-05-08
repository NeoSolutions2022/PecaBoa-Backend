using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IOrcamentoRepository : IRepository<Orcamento>
{
    void Adicionar(Orcamento orcamento);
    void Alterar(Orcamento orcamento);
    Task<Orcamento?> ObterPorId(int id);
    Task<IResultadoPaginado<Orcamento>> Buscar(IBuscaPaginada<Orcamento> filtro);
    void Remover(Orcamento orcamento);
}