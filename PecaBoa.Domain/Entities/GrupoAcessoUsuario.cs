using PecaBoa.Domain.Contracts;

namespace PecaBoa.Domain.Entities;

public class GrupoAcessoUsuario : Entity, IAggregateRoot, ISoftDelete
{
    public int UsuarioId { get; set; }
    public int GrupoAcessoId { get; set; }
    public bool Desativado { get; set; }

    public virtual GrupoAcesso GrupoAcesso { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
}