namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class AlterarOrcamentoDto
{
    public int Id { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly PrazoDeEntrega { get; set; }
    public decimal Preco { get; set; }
    public string? CondicaoDaPeca { get; set; }
    public int PedidoId { get; set; }
    public int LojistaId { get; set; }
    public bool Desativado { get; set; }
}