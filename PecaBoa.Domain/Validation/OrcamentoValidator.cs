using FluentValidation;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Validation;

public class OrcamentoValidator : AbstractValidator<Orcamento>
{
    public OrcamentoValidator()
    {
        RuleFor(p => p.Observacoes)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.DataDeEntrega)
            .NotNull()
            .NotEmpty();
    }
}