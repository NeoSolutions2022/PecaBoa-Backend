using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class CadastrarOrcamentoDto
{
    public IFormFile Foto { get; set; } = null!;
    public IFormFile? Foto2 { get; set; }
    public IFormFile? Foto3 { get; set; }
    public IFormFile? Foto4 { get; set; }
    public IFormFile? Foto5 { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly PrazoDeEntrega { get; set; }
    public decimal Preco { get; set; }
    public string? CondicaoDaPeca { get; set; }
    public int PedidoId { get; set; }
    public int LojistaId { get; set; }
    public bool Desativado { get; set; }
}