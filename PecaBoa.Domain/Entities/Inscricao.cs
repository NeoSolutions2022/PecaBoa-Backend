using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class Inscricao : Entity, ISoftDelete, IAggregateRoot
{
    public int LojistaId { get; set; }
    public bool Desativado { get; set; }
    public bool EhRecorrente { get; set; }
    public DateTime InscricaoAcabaEm { get; set; }
    public Lojista Lojista { get; set; } = null!;
}