using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Lojista;

public class AlterarFotoLojistaDto
{
    public IFormFile Foto { get; set; } = null!;
}