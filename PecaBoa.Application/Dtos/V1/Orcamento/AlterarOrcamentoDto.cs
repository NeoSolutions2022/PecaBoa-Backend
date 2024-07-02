using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class AlterarOrcamentoDto
{
    public int Id { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly PrazoDeEntrega { get; set; }
    public decimal Preco { get; set; }
    public int CondicaoPecaId { get; set; }
    public int PedidoId { get; set; }
    public IFormFile? Foto { get; set; }
    public IFormFile? Foto2 { get; set; }
    public IFormFile? Foto3 { get; set; }
    public IFormFile? Foto4 { get; set; }
    public IFormFile? Foto5 { get; set; }
}