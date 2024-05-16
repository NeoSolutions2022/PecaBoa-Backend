using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class PedidoDto
{
    public int Id { get; set; }
    public string Foto { get; set; } = null!;
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public string NomePeca { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public DateOnly AnoDeFabricacao { get; set; }
    public string Cor { get; set; } = null!;
    public bool Desativado { get; set; }
    public int UsuarioId { get; set; }
    public string Categoria { get; set; } = null!;
    public string? Caracteristica { get; set; }
    public UsuarioDto? Usuario { get; set; }
    public List<OrcamentoDto> Orcamentos { get; set; } = new();
}