using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class Modelo : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;
    public int MarcaId { get; set; }

    public Marca Marca { get; set; } = null!;
}