﻿using FluentValidation;
using FluentValidation.Results;

namespace PecaBoa.Application.Dtos.V1.Administrador;

public class AlterarSenhaAdministradorDto
{
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string ConfirmarSenha { get; set; } = null!;
    public Guid? CodigoResetarSenha { get; set; }

    public bool Validar(out ValidationResult validationResult)
    {
        var validator = new InlineValidator<AlterarSenhaAdministradorDto>();
        
        validator.RuleFor(c => c.Senha)
            .MinimumLength(8)
            .WithMessage("A senha deve ter no mínimo 8 caracteres");
        
        validator.RuleFor(c => c.ConfirmarSenha)
            .NotEmpty()
            .Equal(c => c.Senha)
            .WithMessage("As senhas não conferem.");

        validationResult = validator.Validate(this);
        return validationResult.IsValid;
    }
}   