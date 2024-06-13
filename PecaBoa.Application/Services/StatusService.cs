using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Services;

public class StatusService : IStatusService
{
    private readonly IMapper _mapper;
    private readonly IStatusRepository _statusRepository;

    public StatusService(IMapper mapper, IStatusRepository statusRepository)
    {
        _mapper = mapper;
        _statusRepository = statusRepository;
    }

    public async Task<List<StatusDto>> Listar()
    {
        var status = await _statusRepository.Listar();
        return _mapper.Map<List<StatusDto>>(status);
    }
}