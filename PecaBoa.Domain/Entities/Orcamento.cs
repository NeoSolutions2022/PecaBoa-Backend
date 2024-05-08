using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Orcamento : Entity, IAggregateRoot, ISoftDelete
{
    public int PedidoId { get; set; }
    public int UsuarioId { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly DataDeEntrega { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public bool Desativado { get; set; }

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new OrcamentoValidator().Validate(this);
        return validationResult.IsValid;
    }
}