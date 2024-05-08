using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class OrcamentoDto
{
    public int Id { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly DataDeEntrega { get; set; }
    public int PedidoId { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioDto Usuario { get; set; } = null!;
    public PedidoDto Pedido { get; set; } = null!;
    public bool Desativado { get; set; }
}