using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class Status : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;

    public List<Pedido> Pedidos { get; set; }
    public List<Orcamento> Orcamentos { get; set; }
}