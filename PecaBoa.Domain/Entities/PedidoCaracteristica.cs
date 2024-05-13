using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class PedidoCaracteristica : EntityNotTracked, IAggregateRoot
{
    public string? Valor { get; set; }
    public string? Chave { get; set; }
    public int PedidoId { get; set; }

    public Pedido Pedido { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new PedidoCaracteristicaValidator().Validate(this);
        return validationResult.IsValid;
    }
}