namespace PecaBoa.Application.Dtos.V1.Permissoes;

public class CadastrarPermissaoDto
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Categoria { get; set; } = null!;
}