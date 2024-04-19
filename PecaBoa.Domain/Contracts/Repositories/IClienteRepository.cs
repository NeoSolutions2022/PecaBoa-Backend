using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IClienteRepository : IRepository<Cliente>
{
    void Adicionar(Cliente cliente);
    void Alterar(Cliente cliente);
    Task<Cliente?> ObterPorId(int id);
    Task<Cliente?> ObterPorEmail(string email);
    Task<Cliente?> ObterPorCpf(string cpf);
    void Remover(Cliente cliente);
    Task<IResultadoPaginado<Cliente>> Buscar(IBuscaPaginada<Cliente> filtro);
}