using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IAdministradorRepository : IRepository<Administrador>
{
    void Adicionar(Administrador administrador);
    void Alterar(Administrador administrador);
    void Remover(Administrador administrador);
    Task<Administrador?> ObterPorId(int id);
    Task<Administrador?> ObterPorEmail(string email);
    Task<IResultadoPaginado<Administrador>> Buscar(IBuscaPaginada<Administrador> filtro);
}