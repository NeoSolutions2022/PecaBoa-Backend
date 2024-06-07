using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class CondicaoPeca : Entity, IAggregateRoot
{
    public string Nome { get; set; } = null!;

    public virtual List<Orcamento> Orcamentos { get; set; } = new();
}