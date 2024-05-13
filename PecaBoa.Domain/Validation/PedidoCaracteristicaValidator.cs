using FluentValidation;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Validation;

public class PedidoCaracteristicaValidator : AbstractValidator<PedidoCaracteristica>
{
    public PedidoCaracteristicaValidator()
    {
        RuleFor(c => c.Valor)
            .MaximumLength(255);
        
        RuleFor(c => c.Chave)
            .MaximumLength(50);
    }
}