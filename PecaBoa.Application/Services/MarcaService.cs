using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Marca;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class MarcaService : IMarcaService
{
    private readonly IMapper _mapper;
    private readonly IMarcaRepository _marcaRepository;

    public MarcaService(IMapper mapper, IMarcaRepository marcaRepository)
    {
        _mapper = mapper;
        _marcaRepository = marcaRepository;
    }

    public async Task<List<MarcaDto>> Listar()
    {
        var marcas = await _marcaRepository.Listar();
        return _mapper.Map<List<MarcaDto>>(marcas);
    }
}