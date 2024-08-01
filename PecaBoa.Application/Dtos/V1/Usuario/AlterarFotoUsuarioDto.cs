using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Usuario;

public class AlterarFotoUsuarioDto
{
    public IFormFile Foto { get; set; } = null!;
}