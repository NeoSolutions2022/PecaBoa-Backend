namespace PecaBoa.Application.Dtos.V1.Permissoes;

public class AlterarPermissaoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Categoria { get; set; } = null!;
}