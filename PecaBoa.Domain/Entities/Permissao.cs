using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class Permissao : Entity, IAggregateRoot, ISoftDelete
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public virtual List<GrupoAcessoPermissao> Grupos { get; set; } = null!;
    public bool Desativado { get; set; }
}