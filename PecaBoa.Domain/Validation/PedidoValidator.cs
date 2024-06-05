using FluentValidation;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Validation;

public class PedidoValidator : AbstractValidator<Pedido>
{
    public PedidoValidator()
    {
        RuleFor(p => p.NomePeca)
            .NotEmpty()
            .WithMessage("Nome Peca não pode ser vazio")
            .MaximumLength(180)
            .WithMessage("Nome Peca ter no máximo 180 caracteres");

        RuleFor(p => p.Descricao)
            .NotEmpty()
            .WithMessage("Descricao não pode ser vazio")
            .MaximumLength(1500)
            .WithMessage("Descricao deve ter no máximo 1500 caracteres");

        RuleFor(p => p.Foto)
            .MaximumLength(1500)
            .WithMessage("Foto deve ter no máximo 1500 caracteres");

        RuleFor(c => c.TipoDePeca)
            .NotNull()
            .WithMessage("Tipo De Peça não pode ser nulo")
            .NotEmpty()
            .WithMessage("Tipo de Peça deve conter ao menos um item");

        RuleFor(c => c.Marca)
            .NotNull()
            .WithMessage("Marca não pode ser vazio")
            .MaximumLength(180)
            .WithMessage("Marca deve ter no máximo 180 caracteres");

        RuleFor(c => c.Modelo)
            .NotNull()
            .WithMessage("Modelo não pode ser vazio")
            .MaximumLength(280)
            .WithMessage("Modelo deve ter no máximo 280 caracteres");

        RuleFor(c => c.Cor)
            .NotNull()
            .WithMessage("Cor não pode ser vazio")
            .MaximumLength(180)
            .WithMessage("Cor deve ter no máximo 180 caracteres");
    }
}