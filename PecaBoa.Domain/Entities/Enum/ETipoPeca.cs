using System.ComponentModel;

namespace PecaBoa.Domain.Entities.Enum;

public enum ETipoPeca
{
    [Description("Mecânica")]
    Mecanica = 1,
    [Description("Lataria e acabamento externo")]
    LatariaEAcabamentoExterno = 2,
    [Description("Elétrica, faróis e lanternas")]
    EletricaFaroisELanternas = 3,
    [Description("Painéis, bancos e acabamento interno")]
    PaineisBancosEAcabamentoInterno = 4,
    [Description("Vidros")]
    Vidros = 5,
    [Description("Outros")]
    Outros = 6,
}