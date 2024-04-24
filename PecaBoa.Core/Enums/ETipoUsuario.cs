using System.ComponentModel;

namespace PecaBoa.Core.Enums;

public enum ETipoUsuario
{
    [Description("Administrador")]
    Administrador = 1,
    [Description("Fornecedor")]
    Fornecedor = 2,
    [Description("Usuario")]
    Usuario = 3
}