using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Dtos.V1.Lojista.Inscricoes;

public class InscricaoDto
{
    public int Id { get; set; }
    public bool Desativado { get; set; }
    public bool EhRecorrente { get; set; }
    public DateTime InscricaoAcabaEm { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioDto Usuario { get; set; } = null!;
}