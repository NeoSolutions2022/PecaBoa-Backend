using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class Marca : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;

    public List<Pedido> Pedidos { get; set; } = new();
    public List<Modelo> Modelos { get; set; } = new();
}