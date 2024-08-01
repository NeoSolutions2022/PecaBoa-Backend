using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Modelo;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class ModeloService : IModeloService
{
    private readonly IMapper _mapper;
    private readonly IModeloRepository _modeloRepository;

    public ModeloService(IMapper mapper, IModeloRepository modeloRepository)
    {
        _mapper = mapper;
        _modeloRepository = modeloRepository;
    }

    public async Task<List<ModeloDto>> Listar()
    {
        var modelos = await _modeloRepository.Listar();
        return _mapper.Map<List<ModeloDto>>(modelos);
    }

    public async Task<List<ModeloDto>> ListarPorMarcaId(int marcaId)
    {
        var modelos = await _modeloRepository.ListarPorMarcaId(marcaId);
        return _mapper.Map<List<ModeloDto>>(modelos);
    }
}