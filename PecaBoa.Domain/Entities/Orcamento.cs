using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Orcamento : Entity, IAggregateRoot, ISoftDelete
{
    public int PedidoId { get; set; }
    public int LojistaId { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly PrazoDeEntrega { get; set; }
    public decimal Preco { get; set; }
    public bool Desativado { get; set; }
    public int CondicaoPecaId { get; set; }
    public int StatusId { get; set; }
    public string? Foto { get; set; }
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    
    public Pedido Pedido { get; set; } = null!;
    public Lojista Lojista { get; set; } = null!;
    public CondicaoPeca CondicaoPeca { get; set; } = null!;
    public Status Status { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new OrcamentoValidator().Validate(this);
        return validationResult.IsValid;
    }
}