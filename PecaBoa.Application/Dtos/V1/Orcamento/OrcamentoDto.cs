using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;
using PecaBoa.Application.Dtos.V1.Usuario.Status;

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
    public int CondicaoPecaId { get; set; }
    public int StatusId { get; set; }
    public int PedidoId { get; set; }
    public int LojistaId { get; set; }
    public bool Desativado { get; set; }
    public DateTime CriadoEm { get; set; }

    public CondicaoPecaDto CondicaoPeca { get; set; } = null!;
    public StatusDto Status { get; set; } = null!;
    public LojistaDto Lojista { get; set; } = null!;
    public PedidoDto Pedido { get; set; } = null!;
}