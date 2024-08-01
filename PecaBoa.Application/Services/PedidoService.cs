using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Pedido;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using PecaBoa.Core.Authorization;
using PecaBoa.Domain.Entities.Enum;

namespace PecaBoa.Application.Services;

public class PedidoService : BaseService, IPedidoService
{
    private readonly IAuthenticatedUser _authenticatedUser;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILojistaRepository _lojistaRepository;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PedidoService(IMapper mapper, INotificator notificator,
        IPedidoRepository pedidoRepository, IFileService fileService,
        IHttpContextAccessor httpContextAccessor, IAuthenticatedUser authenticatedUser, IUsuarioRepository usuarioRepository, ILojistaRepository lojistaRepository) : base(mapper, notificator)
    {
        _pedidoRepository = pedidoRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
        _authenticatedUser = authenticatedUser;
        _usuarioRepository = usuarioRepository;
        _lojistaRepository = lojistaRepository;
    }

    public async Task<PedidoDto?> Adicionar(CadastrarPedidoDto dto)
    {
        var pedido = Mapper.Map<Pedido>(dto);

        if (dto.Foto is { Length : > 0 })
        {
            pedido.Foto = await _fileService.Upload(dto.Foto);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5);
        }

        pedido.UsuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId());
        pedido.Desativado = false;
        pedido.StatusId = (int)EStatus.AnuncioAtivo;
        pedido.CriadoEm = DateTime.UtcNow;
        pedido.AtualizadoEm = DateTime.UtcNow;

        pedido.DataFim = DateTime.SpecifyKind(pedido.CriadoEm.AddHours(24), DateTimeKind.Unspecified);
        pedido.DataLimite = DateTime.SpecifyKind(pedido.CriadoEm.AddDays(3), DateTimeKind.Unspecified);
        
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
            pedido.Foto = await _fileService.Upload(dto.Foto);
        }
        else
        {
            pedido.Foto = null;
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2);
        }
        else
        {
            pedido.Foto2 = null;
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3);
        }
        else
        {
            pedido.Foto3 = null;
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4);
        }
        else
        {
            pedido.Foto4 = null;
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5);
        }
        else
        {
            pedido.Foto5 = null;
        }

        if (!await Validar(pedido))
        {
            return null;
        }

        pedido.AtualizadoEm = DateTime.UtcNow;
        pedido.Desativado = false;
        pedido.StatusId = (int)EStatus.AnuncioAtivo;
        _pedidoRepository.Alterar(pedido);
        if (await _pedidoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<PedidoDto>(pedido);
        }

        Notificator.Handle("Não foi possível alterar o pedido!");
        return null;
    }

    public async Task<List<PedidoDto>> BuscarPedidosUsuario()
    {
        var usuario = await _usuarioRepository.ObterPorId(_authenticatedUser.Id);
        if (usuario == null)
        {
            Notificator.Handle("Nenhum usuario encontrado com o id informado.");
            return null;
        }

        var pedidos = await _pedidoRepository.BuscarPedidoUsuario(_authenticatedUser.Id);

        return Mapper.Map<List<PedidoDto>>(pedidos);
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
            pedido.Foto = await _fileService.Upload(dto.Foto);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            pedido.Foto2 = await _fileService.Upload(dto.Foto2);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            pedido.Foto3 = await _fileService.Upload(dto.Foto3);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            pedido.Foto4 = await _fileService.Upload(dto.Foto4);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            pedido.Foto5 = await _fileService.Upload(dto.Foto5);
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

    public async Task<bool> RenovarPedido(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);

        if (pedido == null)
        {
            Notificator.Handle("Pedido não encontrado.");
            return false;
        }

        if (pedido.DataLimite <= DateTime.UtcNow)
        {
            Notificator.Handle("O pedido passou do limite de renovação.");
            return false;
        }

        if (pedido.Desativado)
        {
            Notificator.Handle("O pedido já está desativado.");
            return false;
        }

        if (pedido.DataFim.AddDays(1) <= pedido.DataLimite)
        {
            pedido.DataFim = pedido.DataFim.AddDays(1);
            pedido.AtualizadoEm = DateTime.UtcNow;

            _pedidoRepository.Alterar(pedido);
            return await _pedidoRepository.UnitOfWork.Commit();
        }
        
        Notificator.Handle("O pedido não pode ser renovado pois já atingiu o limite de renovação.");
        return false;
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
        pedido.StatusId = (int)EStatus.Cancelado;
        pedido.AtualizadoEm = DateTime.SpecifyKind(pedido.AtualizadoEm, DateTimeKind.Utc);
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
        pedido.AtualizadoEm = DateTime.SpecifyKind(pedido.AtualizadoEm, DateTimeKind.Utc);
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
        var lojistaId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId());
        var lojista = await _lojistaRepository.ObterPorId(lojistaId);

        if (dto.BuscarTodos && string.IsNullOrEmpty(dto.Uf) && string.IsNullOrEmpty(dto.Cidade))
        {
            dto.Cidade = lojista.Cidade;
        }
        
        var pedidos = await _pedidoRepository.Buscar(dto);
        var pedidosMapeados = Mapper.Map<PagedDto<PedidoDto>>(pedidos);
        
        var httpClient = new HttpClient();
        foreach (var pedidoDto in pedidosMapeados.Itens)
        {
            if (!string.IsNullOrEmpty(pedidoDto.Foto))
            {
                pedidoDto.FotoByte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto);
            }
            if (!string.IsNullOrEmpty(pedidoDto.Foto2))
            {
                pedidoDto.Foto2Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto2);
            }
            if (!string.IsNullOrEmpty(pedidoDto.Foto3))
            {
                pedidoDto.Foto3Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto3);
            }
            if (!string.IsNullOrEmpty(pedidoDto.Foto4))
            {
                pedidoDto.Foto4Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto4);
            }
            if (!string.IsNullOrEmpty(pedidoDto.Foto5))
            {
                pedidoDto.Foto5Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto5);
            }
        }

        return pedidosMapeados;
    }

    public async Task<PedidoDto?> ObterPorId(int id)
    {
        var pedido = await _pedidoRepository.ObterPorId(id);
        if (pedido is null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }
        
        var httpClient = new HttpClient();
        var pedidoDto = Mapper.Map<PedidoDto>(pedido);
        if (!string.IsNullOrEmpty(pedidoDto.Foto))
        {
            pedidoDto.FotoByte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto);
        }
        if (!string.IsNullOrEmpty(pedidoDto.Foto2))
        {
            pedidoDto.Foto2Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto2);
        }
        if (!string.IsNullOrEmpty(pedidoDto.Foto3))
        {
            pedidoDto.Foto3Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto3);
        }
        if (!string.IsNullOrEmpty(pedidoDto.Foto4))
        {
            pedidoDto.Foto4Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto4);
        }
        if (!string.IsNullOrEmpty(pedidoDto.Foto5))
        {
            pedidoDto.Foto5Byte = await DownloadPhotoAsync(httpClient, pedidoDto.Foto5);
        }
        
        return pedidoDto;
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

        return !Notificator.HasNotification;
    }
    
    private async Task<byte[]> DownloadPhotoAsync(HttpClient httpClient, string photoUrl)
    {
        try
        {
            var response = await httpClient.GetAsync(photoUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            return new byte[0];
        }
    }
}