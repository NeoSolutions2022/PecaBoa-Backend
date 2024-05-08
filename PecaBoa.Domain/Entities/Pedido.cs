using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Pedido : Entity, IAggregateRoot, ISoftDelete
{
    public string? Foto { get; set; }
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public double Preco { get; set; }
    public double PrecoDesconto { get; set; }
    public bool Desativado { get; set; }
    public int LojistaId { get; set; }
    public string Categoria { get; set; } = null!;
    public string? Caracteristica { get; set; }
    public Lojista Lojista { get; set; } = null!;
    public List<PedidoCaracteristica> PedidoCaracteristicas { get; set; } = new();
    public List<Orcamento> Orcamentos { get; set; } = new();

    //public bool AnuncioPago { get; set; }
    //public DateTime? DataPagamentoAnuncio { get; set; }
    //public DateTime? DataExpiracaoAnuncio { get; set; }

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new PedidoValidator().Validate(this);
        return validationResult.IsValid;
    }
}