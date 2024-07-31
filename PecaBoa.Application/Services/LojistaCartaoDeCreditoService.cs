using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Lojista.LojistaCartoesDeCredito;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Services;

public class LojistaCartaoDeCreditoService : BaseService, ILojistaCartaoDeCreditoService
{
    private readonly ILojistaCartaoDeCreditoRepository _lojistaCartaoDeCreditoRepository;
    private readonly IAuthenticatedUser _authenticatedUser;
    public LojistaCartaoDeCreditoService(IMapper mapper, INotificator notificator, ILojistaCartaoDeCreditoRepository lojistaCartaoDeCreditoRepository, IAuthenticatedUser authenticatedUser) : base(mapper, notificator)
    {
        _lojistaCartaoDeCreditoRepository = lojistaCartaoDeCreditoRepository;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<List<LojistaCartaoDeCreditoDto>> GetAll()
    {
        var userCreditCards = await _lojistaCartaoDeCreditoRepository.GetAll();
        return Mapper.Map<List<LojistaCartaoDeCreditoDto>>(userCreditCards);
    }

    public async Task<LojistaCartaoDeCreditoDto?> GetById(int id)
    {
        var userCreditCard = await _lojistaCartaoDeCreditoRepository.GetById(id);
        return Mapper.Map<LojistaCartaoDeCreditoDto>(userCreditCard);
    }

    public async Task<LojistaCartaoDeCreditoDto?> Create(CreateLojistaCartaoDeCreditoDto dto)
    {
        var userCreditCard = Mapper.Map<LojistaCartaoDeCredito>(dto);
        if (await _lojistaCartaoDeCreditoRepository.Any(c => c.Number == userCreditCard.Number && c.Id != userCreditCard.Id))
        {
            return null;
        }

        if (!Validate(userCreditCard))
        {
            return null;
        }
        
        _lojistaCartaoDeCreditoRepository.Create(userCreditCard);
        if (await _lojistaCartaoDeCreditoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<LojistaCartaoDeCreditoDto>(userCreditCard);
        }
        
        Notificator.Handle("Erro ao salvar cartão de crédito.");
        return null;
    }

    public async Task<LojistaCartaoDeCreditoDto?> Update(int id, UpdateLojistaCartaoDeCreditoDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem.");
            return null;
        }
        
        var userCreditCard = await _lojistaCartaoDeCreditoRepository.GetById(id);
        if (userCreditCard is null)
        {
            Notificator.Handle("Cartão de crédito não encontrado.");
            return null;
        }

        Mapper.Map(dto, userCreditCard);
        if (!Validate(userCreditCard))
        {
            return null;
        }

        _lojistaCartaoDeCreditoRepository.Update(userCreditCard);
        if (await _lojistaCartaoDeCreditoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<LojistaCartaoDeCreditoDto>(userCreditCard);
        }
        
        Notificator.Handle("Erro ao atualizar cartão de crédito.");
        return null;
    }

    public async Task Remove(int id)
    {
        var userCreditCard = await _lojistaCartaoDeCreditoRepository.GetById(id);
        if (userCreditCard is null)
        {
            Notificator.Handle("Cartão de crédito não encontrado.");
            return;
        }

        _lojistaCartaoDeCreditoRepository.Remove(userCreditCard);
        if (await _lojistaCartaoDeCreditoRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Erro ao remover cartão de crédito.");
    }
    
    private bool Validate(LojistaCartaoDeCredito userCreditCard)
    {
        if (!userCreditCard.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
        
        return !Notificator.HasNotification;
    }
}