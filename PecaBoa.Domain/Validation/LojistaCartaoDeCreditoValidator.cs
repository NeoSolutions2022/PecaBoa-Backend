using FluentValidation;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Validation;

public class LojistaCartaoDeCreditoValidator : AbstractValidator<LojistaCartaoDeCredito>
{
    public LojistaCartaoDeCreditoValidator()
    {
        RuleFor(card => card.HolderName)
            .NotEmpty().WithMessage("O nome do titular do cartão é obrigatório.");

        RuleFor(card => card.Number)
            .NotEmpty().WithMessage("O número do cartão é obrigatório.")
            .CreditCard().WithMessage("Número de cartão de crédito inválido.");

        RuleFor(card => card.ExpiryMonth)
            .NotEmpty().WithMessage("O mês de validade do cartão é obrigatório.")
            .Matches(@"^(0[1-9]|1[0-2])$").WithMessage("Mês de validade inválido.");

        RuleFor(card => card.ExpiryYear)
            .NotEmpty().WithMessage("O ano de validade do cartão é obrigatório.")
            .Matches(@"^\d{2}$").WithMessage("Ano de validade inválido.");

        RuleFor(card => card.Ccv)
            .NotEmpty()
            .WithMessage("O código de segurança do cartão é obrigatório.")
            .Matches(@"^\d{3,4}$")
            .WithMessage("Código de segurança inválido.");
        
        RuleFor(card => card.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido.");

        RuleFor(card => card.CpfCnpj)
            .Matches(@"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
    }
}