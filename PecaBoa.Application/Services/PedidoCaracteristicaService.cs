using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace PecaBoa.Application.Services;

public class PedidoCaracteristicaService : BaseService, IPedidoCaracteristicaService
{
    private readonly IPedidoCaracteristicaRepository _repository;
    private readonly HttpContextAccessor _httpContextAccessor;
    public PedidoCaracteristicaService(IMapper mapper, INotificator notificator, IPedidoCaracteristicaRepository repository, IOptions<HttpContextAccessor> httpContextAccessor) : base(mapper, notificator)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor.Value;
    }

    public async Task<List<PedidoCaracteristicaDto>?> Adicionar(List<AdicionarPedidoCaracteristicaDto> dto)
    {
        var pedidoCaracteristica = Mapper.Map<List<PedidoCaracteristica>>(dto);
        foreach (var produto in pedidoCaracteristica)
        {
            if (!await Validar(produto))
            {
                return null;
            }
        }

        _repository.Adicionar(pedidoCaracteristica);

        if (await _repository.UnitOfWork.Commit())
        {
            return Mapper.Map<List<PedidoCaracteristicaDto>>(pedidoCaracteristica);
        }

        Notificator.Handle("Não foi possível salvar o pedido!");
        return null;
    }

    public async Task<PedidoCaracteristicaDto?> Alterar(int id, AlterarPedidoCaracteristicaDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var pedidoCaracteristica = await _repository.ObterPorId(id);
        if (pedidoCaracteristica == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, pedidoCaracteristica);
        if (!await Validar(pedidoCaracteristica))
        {
            return null;
        }

        _repository.Alterar(pedidoCaracteristica);
        if (await _repository.UnitOfWork.Commit())
        {
            return Mapper.Map<PedidoCaracteristicaDto>(pedidoCaracteristica);
        }

        Notificator.Handle("Não foi possível alterar o pedido!");
        return null;
    }

    public async Task<PedidoCaracteristicaDto?> ObterPorId(int id)
    {
        var pedidoCaracteristica = await _repository.ObterPorId(id);
        if (pedidoCaracteristica != null)
        {
            return Mapper.Map<PedidoCaracteristicaDto>(pedidoCaracteristica);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task<List<PedidoCaracteristicaDto>?> ObterPorTodos(int produtoId)
    {
        var pedidoCaracteristica = await _repository.ObterTodos(produtoId);
        if (pedidoCaracteristica != null)
        {
            return Mapper.Map<List<PedidoCaracteristicaDto>>(pedidoCaracteristica);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task Remover(int id)
    {
        var pedidoCaracteristica = await _repository.ObterPorId(id);
        if (pedidoCaracteristica is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        _repository.Remover(pedidoCaracteristica);
        if (await _repository.UnitOfWork.Commit())
        {
            _repository.Remover(pedidoCaracteristica);
            return;
        }

        Notificator.Handle("Não foi possível remover o pedido");
    }
    
    private async Task<bool> Validar(PedidoCaracteristica produtoCaracteristica)
    {
        if (!produtoCaracteristica.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
            
        var caracteristicaExistente =
            await _repository.FistOrDefault(
                c => c.Chave == produtoCaracteristica.Chave && c.Id != produtoCaracteristica.Id);
        if (caracteristicaExistente != null)
        {
            Notificator.Handle("Já existe uma caracteristica com essa chave!");
        }

        if (caracteristicaExistente != null && caracteristicaExistente.Pedido.UsuarioId != Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()))
        {
            Notificator.Handle("Você não tem permição para executar essa ação!");
        }

        return !Notificator.HasNotification;
    }
}