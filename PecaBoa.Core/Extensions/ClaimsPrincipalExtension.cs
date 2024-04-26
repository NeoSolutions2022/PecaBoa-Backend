using System.Security.Claims;
using Newtonsoft.Json;
using PecaBoa.Core.Authorization;

namespace PecaBoa.Core.Extensions;

public static class ClaimsPrincipalExtension
{
    public static List<PermissaoClaim> Permissoes(this ClaimsPrincipal? user)
    {
        if (user is null)
        {
            return new List<PermissaoClaim>();
        }

        return user.Claims
            .Where(c => c.Type == "permissoes")
            .SelectMany(c => JsonConvert.DeserializeObject<List<PermissaoClaim>>(c.Value)!)
            .ToList();
    }

    public static bool UsuarioAutenticado(this ClaimsPrincipal? principal)
    {
        return principal?.Identity!.IsAuthenticated ?? false;
    }
//ToDo: conflito de nomes: ObterTipoDeUsuarios
    public static string? ObterTipoUsuarios(this ClaimsPrincipal? principal) => GetClaim(principal, "TipoUsuario");

    public static string? ObterTipoAdministrador(this ClaimsPrincipal? principal) =>
        GetClaim(principal, "Administrador");

    public static string? ObterTipoLojista(this ClaimsPrincipal? principal) => GetClaim(principal, "Lojista");

    public static string? ObterTipoUsuario(this ClaimsPrincipal? principal) => GetClaim(principal, "Usuario");

    public static string? ObterUsuarioId(this ClaimsPrincipal? principal) =>
        GetClaim(principal, ClaimTypes.NameIdentifier);


    private static string? GetClaim(ClaimsPrincipal? principal, string claimName)
    {
        if (principal == null)
        {
            throw new ArgumentException(null, nameof(principal));
        }

        var claim = principal.FindFirst(claimName);
        return claim?.Value;
    }
}