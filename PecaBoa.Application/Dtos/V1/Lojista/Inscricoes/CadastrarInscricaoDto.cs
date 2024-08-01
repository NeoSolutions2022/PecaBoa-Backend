using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;

namespace PecaBoa.Application.Dtos.V1.Lojista.Inscricoes;

public class CadastrarInscricaoDto
{
    public bool IsRecurrent { get; set; }
    public int LojistaId { get; set; }
    public CreditCard? CreditCard { get; set; }
    public CreditCardHolderInfo? CreditCardHolderInfo { get; set; }
}