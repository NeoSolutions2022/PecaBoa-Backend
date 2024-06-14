using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Application.Dtos.V1.Usuario.Marca;
using PecaBoa.Application.Dtos.V1.Usuario.Modelo;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class PedidoDto
{
    public int Id { get; set; }
    public string Foto { get; set; } = null!;
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public byte[]? FotoByte { get; set; }
    public byte[]? Foto2Byte { get; set; }
    public byte[]? Foto3Byte { get; set; }
    public byte[]? Foto4Byte { get; set; }
    public byte[]? Foto5Byte { get; set; }
    public string NomePeca { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int MarcaId { get; set; }
    public int ModeloId { get; set; }
    public int StatusId { get; set; }
    public int TipoDePecaId { get; set; }
    public int CategoriaVeiculoId { get; set; }
    public DateOnly AnoDeFabricacao { get; set; }
    public string Cor { get; set; } = null!;
    public bool Desativado { get; set; }
    public int UsuarioId { get; set; }

    public UsuarioDto Usuario { get; set; } = null!;
    public MarcaDto Marca { get; set; } = null!;
    public ModeloDto Modelo { get; set; } = null!;
    public StatusDto Status { get; set; } = null!;
    public TipoDePecaDto TipoDePeca { get; set; } = null!;
    public CategoriaVeiculoDto CategoriaVeiculo { get; set; } = null!;
    public List<OrcamentoDto> Orcamentos { get; set; } = new();
}