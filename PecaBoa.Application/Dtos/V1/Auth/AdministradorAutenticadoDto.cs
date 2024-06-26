﻿namespace PecaBoa.Application.Dtos.V1.Auth;

public class AdministradorAutenticadoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}