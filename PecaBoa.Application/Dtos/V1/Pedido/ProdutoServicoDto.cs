using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class PedidoDto
{
    public int Id { get; set; }
    public string Foto { get; set; } = null!;
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public double Preco { get; set; }
    public double PrecoDesconto { get; set; }
    public bool Desativado { get; set; }
    public int LojistaId { get; set; }
    public string Categoria { get; set; } = null!;
    public string? Caracteristica { get; set; }
    public LojistaDto? Lojista { get; set; }
    public List<PedidoCaracteristicaDto> PedidoCaracteristicas { get; set; } = new();
}