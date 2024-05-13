using PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;

namespace PecaBoa.Application.Contracts;

public interface IPedidoCaracteristicaService
{
    Task<List<PedidoCaracteristicaDto>?> Adicionar(List<AdicionarPedidoCaracteristicaDto> dto);
    Task<PedidoCaracteristicaDto?> Alterar(int id, AlterarPedidoCaracteristicaDto dto);
    Task<PedidoCaracteristicaDto?> ObterPorId(int id);
    Task<List<PedidoCaracteristicaDto>?> ObterPorTodos(int produtoId);
    Task Remover(int id);
}