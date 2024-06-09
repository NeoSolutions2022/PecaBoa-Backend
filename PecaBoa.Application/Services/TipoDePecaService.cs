using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class TipoDePecaService : ITipoDePecaService
{
    private readonly IMapper _mapper;
    private readonly ITipoDePecaRepository _tipoDePecaRepository;

    public TipoDePecaService(IMapper mapper, ITipoDePecaRepository tipoDePecaRepository)
    {
        _mapper = mapper;
        _tipoDePecaRepository = tipoDePecaRepository;
    }

    public async Task<List<TipoDePecaDto>> Listar()
    {
        var tipoDePeca = await _tipoDePecaRepository.Listar();
        return _mapper.Map<List<TipoDePecaDto>>(tipoDePeca);
    }
}