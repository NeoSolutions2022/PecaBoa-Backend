using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class CategoriaVeiculo : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;

    public List<Pedido> Pedidos { get; set; } = null!;
}