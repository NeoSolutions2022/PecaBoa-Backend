using System.ComponentModel;

namespace PecaBoa.Domain.Entities.Enum;

public enum EStatusUsuario
{
    [Description("Em Análise")]
    EmAnalise = 1,
    [Description("Aprovado")]
    Aprovado = 2,
    [Description("Negado")]
    Negado = 3
}