using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Domain.Entities.Enum;

namespace PecaBoa.Application.Services;

public class OrcamentoService : BaseService, IOrcamentoService
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IAuthenticatedUser _authenticatedUser;
    
    public OrcamentoService(IMapper mapper, INotificator notificator, IOrcamentoRepository orcamentoRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor, IPedidoRepository pedidoRepository,  IAuthenticatedUser authenticatedUser) : base(mapper, notificator)
    {
        _orcamentoRepository = orcamentoRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
        _pedidoRepository = pedidoRepository;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<OrcamentoDto?> Adicionar(CadastrarOrcamentoDto dto)
    {
        var orcamento = Mapper.Map<Orcamento>(dto);
        
        if (dto.Foto is { Length : > 0 })
        {
            orcamento.Foto = await _fileService.Upload(dto.Foto);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            orcamento.Foto2 = await _fileService.Upload(dto.Foto2);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            orcamento.Foto3 = await _fileService.Upload(dto.Foto3);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            orcamento.Foto4 = await _fileService.Upload(dto.Foto4);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            orcamento.Foto5 = await _fileService.Upload(dto.Foto5);
        }
        
        orcamento.LojistaId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId());
        orcamento.Desativado = false;
        orcamento.StatusId = (int)EStatus.AnuncioAtivo;
        orcamento.CriadoEm = DateTime.UtcNow;
        orcamento.AtualizadoEm = DateTime.UtcNow;

        var pedido = await _pedidoRepository.ObterPorId(dto.PedidoId);
        if (pedido == null)
        {
            Notificator.Handle("Não existe pedido com o Id informado.");
            return null;
        }
        
        if (pedido.Orcamentos.Count >= 10)
        {
            Notificator.Handle("O Pedido selecionado atingiu o limite de orçamentos");
            return null;
        }
        
        _orcamentoRepository.Adicionar(orcamento);
        
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<OrcamentoDto>(orcamento);
        }
        
        Notificator.Handle("Não foi possível adicionar o Orcamento");
        return null;
    }

    public async Task<OrcamentoDto?> Alterar(int id, AlterarOrcamentoDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem!");
            return null;
        }

        var orcamento = await _orcamentoRepository.ObterPorId(id);
        if (orcamento == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, orcamento);
        
        orcamento.LojistaId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.ObterUsuarioId());
        orcamento.AtualizadoEm = DateTime.UtcNow;
        orcamento.Desativado = false;
        orcamento.StatusId = (int)EStatus.AnuncioAtivo;
        _orcamentoRepository.Alterar(orcamento);
        
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<OrcamentoDto>(orcamento);
        }
        
        Notificator.Handle("Não foi possível alterar o Orçamento");
        return null;
    }

    public async Task<OrcamentoDto?> ObterPorId(int id)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(id);
        
        if (orcamento != null)
        {
            return Mapper.Map<OrcamentoDto>(orcamento);
        }
        
        Notificator.HandleNotFoundResource();
        return null;
    }

    public async Task Desativar(int id)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(id);
        
        if (orcamento == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        orcamento.Desativado = true;
        orcamento.AtualizadoEm = DateTime.SpecifyKind(orcamento.AtualizadoEm, DateTimeKind.Utc);
        _orcamentoRepository.Alterar(orcamento);
        
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar o Orçamento");
    }

    public async Task Reativar(int id)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(id);
        
        if (orcamento == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        orcamento.Desativado = false;
        orcamento.AtualizadoEm = DateTime.SpecifyKind(orcamento.AtualizadoEm, DateTimeKind.Utc);
        _orcamentoRepository.Alterar(orcamento);
        
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível reativar o Orçamento");
    }

    public async Task Remover(int id)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(id);
        if (orcamento == null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        _orcamentoRepository.Remover(orcamento);
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível remover o Orçamento");
    }

    public async Task<PagedDto<OrcamentoDto>> Buscar(BuscarOrcamentoDto dto)
    {
        var orcamentos = await _orcamentoRepository.Buscar(dto);
        return Mapper.Map<PagedDto<OrcamentoDto>>(orcamentos);
    }

    public async Task<List<OrcamentoDto>> BuscarOrcamentosLojista()
    {
        var orcamentos = await _orcamentoRepository.BuscarOrcamentosLojista(_authenticatedUser.Id);

        return Mapper.Map<List<OrcamentoDto>>(orcamentos);
    }

    public async Task AlterarFoto(AlterarFotoOrcamentoDto dto)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(dto.Id);
        if (orcamento is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        if (dto.Foto is { Length : > 0 })
        {
            orcamento.Foto = await _fileService.Upload(dto.Foto);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            orcamento.Foto2 = await _fileService.Upload(dto.Foto2);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            orcamento.Foto3 = await _fileService.Upload(dto.Foto3);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            orcamento.Foto4 = await _fileService.Upload(dto.Foto4);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            orcamento.Foto5 = await _fileService.Upload(dto.Foto5);
        }

        _orcamentoRepository.Alterar(orcamento);
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return;
        }

        Notificator.Handle("Não foi possível alterar as fotos");
    }

    public async Task RemoverFoto(RemoverFotosOrcamentoDto dto)
    {
        var orcamento = await _orcamentoRepository.ObterPorId(dto.Id);
        if (orcamento is null)
        {
            Notificator.HandleNotFoundResource();
            return;
        }

        switch (dto.IndexFoto)
        {
            case 1:
                orcamento.Foto = null;
                break;
            case 2:
                orcamento.Foto2 = null;
                break;
            case 3:
                orcamento.Foto3 = null;
                break;
            case 4:
                orcamento.Foto4 = null;
                break;
            case 5:
                orcamento.Foto5 = null;
                break;
            default:
            {
                Notificator.Handle("Não foi possível alterar a foto");
                return;
            }
        }
        
    }
}