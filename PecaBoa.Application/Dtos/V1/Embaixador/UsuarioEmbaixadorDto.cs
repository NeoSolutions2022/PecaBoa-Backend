using PecaBoa.Domain.Entities.Enum;

namespace PecaBoa.Application.Dtos.V1.Embaixador;

public class UsuarioEmbaixadorDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    private List<UsuarioAnuncianteDto> UsuarioAnuncianteDtos { get; set; } = new();
}

internal class UsuarioAnuncianteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PecaAnunciadas { get; set; }
    public decimal TotalFaturado { get; set; }
    public decimal TotalDaComissao { get; set; }
    public EStatusUsuario Status { get; set; }
}