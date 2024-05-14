using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class AlterarPedidoDto
{
    public int Id { get; set; }
    public string NomePeca { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public DateOnly? AnoDeFabricacao { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public bool Desativado { get; set; }
    public string Categoria { get; set; } = null!;
    public string? Caracteristica { get; set; }
    public IFormFile? Foto { get; set; }
    public IFormFile? Foto2 { get; set; }
    public IFormFile? Foto3 { get; set; }
    public IFormFile? Foto4 { get; set; }
    public IFormFile? Foto5 { get; set; }
}