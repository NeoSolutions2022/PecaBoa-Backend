using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Dtos.V1.GruposDeAcesso;

public class AdicionarUsuarioGrupoAcessoDto
{
    public int UserId { get; set; }
    public List<GrupoAcessoUsuarioDto> GrupoAcesso { get; set; } = new();
}