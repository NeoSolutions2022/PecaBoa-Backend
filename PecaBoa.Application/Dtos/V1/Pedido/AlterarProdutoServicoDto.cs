using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class AlterarPedidoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public double Preco { get; set; }
    public double PrecoDesconto { get; set; }
    public string Descricao { get; set; } = null!;
    public bool Desativado { get; set; }
    public string Categoria { get; set; } = null!;
    public string? Caracteristica { get; set; }
    public IFormFile? Foto { get; set; }
    public IFormFile? Foto2 { get; set; }
    public IFormFile? Foto3 { get; set; }
    public IFormFile? Foto4 { get; set; }
    public IFormFile? Foto5 { get; set; }
}