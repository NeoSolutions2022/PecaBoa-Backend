using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class LojistaCartaoDeCredito : Entity ,IAggregateRoot
{
    public string HolderName { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string LastNumbers { get; set; } = null!;
    public string ExpiryMonth { get; set; } = null!;
    public string ExpiryYear { get; set; } = null!;
    public string Ccv { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CpfCnpj { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string AddressNumber { get; set; } = null!;
    public string Phone { get; set; } = null!;
    
    public string? CreditCardToken { get; set; }
    public int LojistaId { get; set; }
    public Lojista Lojista { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        var validator = new LojistaCartaoDeCreditoValidator();
        validationResult = validator.Validate(this);
        return validationResult.IsValid;
    }
}