using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class CadastrarPedidoDto
{
    public IFormFile Foto { get; set; } = null!;
    public IFormFile? Foto2 { get; set; }
    public IFormFile? Foto3 { get; set; }
    public IFormFile? Foto4 { get; set; }
    public IFormFile? Foto5 { get; set; }
    public string NomePeca { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int MarcaId { get; set; }
    public int ModeloId { get; set; }
    public int TipoDePecaId { get; set; }
    public int CategoriaVeiculoId { get; set; }
    public DateOnly AnoDeFabricacao { get; set; }
    public string Cor { get; set; } = null!;
    //public bool Desativado { get; set; }
}