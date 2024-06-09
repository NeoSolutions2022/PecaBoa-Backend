using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class CategoriaVeiculoService : ICategoriaVeiculoService
{
    private readonly IMapper _mapper;
    private readonly ICategoriaVeiculoRepository _categoriaVeiculoRepository;

    public CategoriaVeiculoService(IMapper mapper, ICategoriaVeiculoRepository categoriaVeiculoRepository)
    {
        _mapper = mapper;
        _categoriaVeiculoRepository = categoriaVeiculoRepository;
    }

    public async Task<List<CategoriaVeiculoDto>> Listar()
    {
        var categoriaVeiculos = await _categoriaVeiculoRepository.Listar();
        return _mapper.Map<List<CategoriaVeiculoDto>>(categoriaVeiculos);
    }
}