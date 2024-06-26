﻿using FluentValidation;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Validation;

public class AdministradorValidator : AbstractValidator<Administrador>
{
    public AdministradorValidator()
    {
        RuleFor(a => a.Nome)
            .NotEmpty();

        RuleFor(a => a.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(a => a.Senha)
            .NotEmpty();
    }
}