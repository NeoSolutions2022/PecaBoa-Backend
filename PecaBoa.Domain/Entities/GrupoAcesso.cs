using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class GrupoAcesso : Entity, IAggregateRoot, ISoftDelete
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public bool Administrador { get; set; }
    public bool Desativado { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual List<GrupoAcessoPermissao> Permissoes { get; set; } = new();  
}