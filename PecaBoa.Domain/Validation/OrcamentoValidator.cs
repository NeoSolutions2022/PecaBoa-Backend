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

        RuleFor(c => c.Preco)
            .NotNull()
            .WithMessage("Preco não pode ser nulo")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Preço deve ser maior que 0");

        RuleFor(p => p.Foto)
            .MaximumLength(1500)
            .WithMessage("Foto deve ter no máximo 1500 caracteres");
        
        RuleFor(p => p.PrazoDeEntrega)
            .NotNull()
            .NotEmpty();
    }
}