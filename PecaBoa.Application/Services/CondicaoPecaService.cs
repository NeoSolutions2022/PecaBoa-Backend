using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class CondicaoPecaService : ICondicaoPecaService
{
    private readonly IMapper _mapper;
    private readonly ICondicaoPecaRepository _condicaoPecaRepository;

    public CondicaoPecaService(IMapper mapper, ICondicaoPecaRepository condicaoPecaRepository)
    {
        _mapper = mapper;
        _condicaoPecaRepository = condicaoPecaRepository;
    }

    public async Task<List<CondicaoPecaDto>> Listar()
    {
        var condicaoPecas = await _condicaoPecaRepository.Listar();
        return _mapper.Map<List<CondicaoPecaDto>>(condicaoPecas);
    }
}