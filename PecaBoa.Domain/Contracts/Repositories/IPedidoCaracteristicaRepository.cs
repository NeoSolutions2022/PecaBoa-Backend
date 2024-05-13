using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IPedidoCaracteristicaRepository : IRepository<PedidoCaracteristica>
{
    void Adicionar(List<PedidoCaracteristica> pedidoCaracteristica);
    void Alterar(PedidoCaracteristica pedidoCaracteristica);
    Task<PedidoCaracteristica?> ObterPorId(int id);
    Task<List<PedidoCaracteristica>?> ObterTodos(int id);
    void Remover(PedidoCaracteristica pedidoCaracteristica);
}