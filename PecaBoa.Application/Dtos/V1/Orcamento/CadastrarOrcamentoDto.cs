namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class CadastrarOrcamentoDto
{
    public string? Observacoes { get; set; }
    public DateOnly DataDeEntrega { get; set; }
    public int PedidoId { get; set; }
    public int UsuarioId { get; set; }
    public bool Desativado { get; set; }
}