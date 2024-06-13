using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;

namespace PecaBoa.Application.Contracts;

public interface ICategoriaVeiculoService
{
    Task<List<CategoriaVeiculoDto>> Listar();
}