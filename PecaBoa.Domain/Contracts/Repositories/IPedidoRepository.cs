using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface IPedidoRepository : IRepository<Pedido>
{
    void Adicionar(Pedido pedido);
    void Alterar(Pedido pedido);
    Task<Pedido?> ObterPorId(int id);
    Task<IResultadoPaginado<Pedido>> Buscar(IBuscaPaginada<Pedido> filtro);
    Task<List<Pedido>> BuscarPedidoUsuario(int id);
    Task<List<Pedido>> ObterPedidosParaInativar();
    void Remover(Pedido pedido);
}