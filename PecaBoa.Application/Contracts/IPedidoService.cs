using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Pedido;

namespace PecaBoa.Application.Contracts;

public interface IPedidoService
{
    Task<PedidoDto?> Adicionar(CadastrarPedidoDto dto);
    Task<PedidoDto?> Alterar(int id, AlterarPedidoDto dto);
    Task<PedidoDto?> ObterPorId(int id);
    Task Desativar(int id);
    Task Reativar(int id);
    Task Remover(int id);
    Task<PagedDto<PedidoDto>> Buscar(BuscarPedidoDto dto);
    Task<List<PedidoDto>> BuscarPedidosUsuario();
    Task AlterarFoto(AlterarFotoPedidoDto dto);
    Task RemoverFoto(RemoverFotosPedidoDto dto);
}