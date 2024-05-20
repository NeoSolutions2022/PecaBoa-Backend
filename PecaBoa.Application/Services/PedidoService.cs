using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Services;

public class PedidoService : BaseService, IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PedidoService(IMapper mapper, INotificator notificator,
        IPedidoRepository pedidoRepository, IFileService fileService,
        IHttpContextAccessor httpContextAccessor) : base(mapper, notificator)
    {
        _pedidoRepository = pedidoRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<PedidoDto?> Adicionar(CadastrarPedidoDto dto)
    {
        var pedido = Mapper.Map<Pedido>(dto);

        if (dto.Foto is { Length : > 0 })
        {
            pedido.Foto = await _fileService.Upload(dto.Foto, EUploadPath.FotoPedido);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2, EUploadPath.FotoPedido);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3, EUploadPath.FotoPedido);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4, EUploadPath.FotoPedido);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5, EUploadPath.FotoPedido);
        }

        pedido.UsuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId());
        pedido.CriadoEm = DateTime.Now;
        if (!await Validar(pedido))
        {
            return null;
        }

        _pedidoRepository.Adicionar(pedido);

        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<PedidoDto>(pedido);
        }

        Notificator.Handle("Não foi possível salvar o pedido!");
        return null;
    }

    public async Task<PedidoDto?> Alterar(int id, AlterarPedidoDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, pedido);

        if (dto.Foto is { Length : > 0 })
        {
            pedido.Foto = await _fileService.Upload(dto.Foto, EUploadPath.FotoPedido);
        }
        else
        {
            pedido.Foto = null;
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2, EUploadPath.FotoPedido);
        }
        else
        {
            pedido.Foto2 = null;
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3, EUploadPath.FotoPedido);
        }
        else
        {
            pedido.Foto3 = null;
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4, EUploadPath.FotoPedido);
        }
        else
        {
            pedido.Foto4 = null;
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5, EUploadPath.FotoPedido);
        }
        else
        {
            pedido.Foto5 = null;
        }

        if (!await Validar(pedido))
        {
            return null;
        }

        pedido.AtualizadoEm = DateTime.Now;
        _pedidoRepository.Alterar(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<PedidoDto>(pedido);
        }

        Notificator.Handle("Não foi possível alterar o pedido!");
        return null;
    }

    public async Task AlterarFoto(AlterarFotoPedidoDto dto)
    {
        var pedido = await _pedidoRepository.ObterPorId(dto.Id);
        if (pedido is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        if (dto.Foto is { Length : > 0 })
        {
            pedido.Foto = await _fileService.Upload(dto.Foto, EUploadPath.FotoPedido);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2, EUploadPath.FotoPedido);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3, EUploadPath.FotoPedido);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4, EUploadPath.FotoPedido);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5, EUploadPath.FotoPedido);
        }

        _pedidoRepository.Alterar(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível alterar as fotos");
    }

    public async Task RemoverFoto(RemoverFotosPedidoDto dto)
    {
        var pedido = await _pedidoRepository.ObterPorId(dto.Id);
        if (pedido is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        switch (dto.IndexFoto)
        {
            case 1:
                pedido.Foto = null;
                break;
            case 2:
                pedido.Foto2 = null;
                break;
            case 3:
                pedido.Foto3 = null;
                break;
            case 4:
                pedido.Foto4 = null;
                break;
            case 5:
                pedido.Foto5 = null;
                break;
            default:
            {
                Notificator.Handle("Não foi possível alterar a foto");
                return;
            }
        }

        _pedidoRepository.Alterar(pedido);

        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível alterar as fotos");
    }

    public async Task Desativar(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        pedido.Desativado = true;
        pedido.AtualizadoEm = DateTime.Now;
        _pedidoRepository.Alterar(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível desativar o pedido!");
    }

    public async Task Reativar(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        pedido.Desativado = false;
        pedido.AtualizadoEm = DateTime.Now;
        _pedidoRepository.Alterar(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível reativar o pedido!");
    }

    public async Task Remover(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }
        
        
        _pedidoRepository.Remover(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível remover o pedido!");
    }

    public async Task<PagedDto<PedidoDto>> Buscar(BuscarPedidoDto dto)
    {
        var administrador = await _pedidoRepository.Buscar(dto);
        return Mapper.Map<PagedDto<PedidoDto>>(administrador);
    }

    public async Task<PedidoDto?> ObterPorId(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido != null)
        {
            return Mapper.Map<PedidoDto>(pedido);
        }

        Notificator.HandleNotFoundResource();
        return null;
    }

    private async Task<bool> Validar(Pedido pedido)
    {
        if (!pedido.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        if (pedido.UsuarioId != Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId()))
        {
            Notificator.Handle("Você não tem permissão para executar essa ação!");
        }

        var administradorExistente =
            await _pedidoRepository.FistOrDefault(
                c => c.NomePeca == pedido.NomePeca && c.Id != pedido.Id);
        if (administradorExistente != null)
        {
            Notificator.Handle("Já existe um administrador com esse email!");
        }

        return !Notificator.HasNotification;
    }
}