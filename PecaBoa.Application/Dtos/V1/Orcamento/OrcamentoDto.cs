using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class OrcamentoDto
{
    public int Id { get; set; }
    public string Foto { get; set; } = null!;
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly PrazoDeEntrega { get; set; }
    public decimal Preco { get; set; }
    public string? CondicaoDaPeca { get; set; }
    public int PedidoId { get; set; }
    public int LojistaId { get; set; }
    public LojistaDto Lojista { get; set; } = null!;
    public PedidoDto Pedido { get; set; } = null!;
    public bool Desativado { get; set; }
}