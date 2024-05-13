using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface ILojistaRepository : IRepository<Lojista>
{
    void Adicionar(Lojista lojista);
    void Alterar(Lojista lojista);
    Task<Lojista?> ObterPorId(int id);
    Task<Lojista?> ObterPorEmail(string email);
    Task<Lojista?> ObterPorCpf(string cpf);
    Task<Lojista?> ObterPorCnpj(string cnpj);
    void Remover(Lojista lojista);
    Task<IResultadoPaginado<Lojista>> Buscar(IBuscaPaginada<Lojista> filtro);
}