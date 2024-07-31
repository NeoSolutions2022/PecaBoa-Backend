namespace PecaBoa.Application.Dtos.V1.Lojista.Inscricoes;

public class AtualizarInscricaoDto
{
    public int Id { get; set; }
    public bool EhRecorrente { get; set; }
    public DateTime InscricaoAcabaEm { get; set; }
    public int UsuarioId { get; set; }
}