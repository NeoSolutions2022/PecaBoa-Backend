using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface ICategoriaVeiculoRepository : IRepository<CategoriaVeiculo>
{
    Task<List<CategoriaVeiculo>> Listar();
}