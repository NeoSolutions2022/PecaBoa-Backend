using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class ProdutoServicoCaracteristica : EntityNotTracked, IAggregateRoot
{
    public string? Valor { get; set; }
    public string? Chave { get; set; }
    public int ProdutoServicoId { get; set; }

    public ProdutoServico ProdutoServico { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new ProdutoServicoCaracteristicaValidator().Validate(this);
        return validationResult.IsValid;
    }
}