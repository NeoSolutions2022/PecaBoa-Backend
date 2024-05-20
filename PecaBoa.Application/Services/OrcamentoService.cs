using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Services;

public class OrcamentoService : BaseService, IOrcamentoService
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IFileService _fileService;
    
    public OrcamentoService(IMapper mapper, INotificator notificator, IOrcamentoRepository orcamentoRepository, IFileService fileService) : base(mapper, notificator)
    {
        _orcamentoRepository = orcamentoRepository;
        _fileService = fileService;
    }

    public async Task<OrcamentoDto?> Adicionar(CadastrarOrcamentoDto dto)
    {
        var orcamento = Mapper.Map<Orcamento>(dto);
        
        orcamento.CriadoEm = DateTime.Now;
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
        
        orcamento.AtualizadoEm = DateTime.Now;
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
        orcamento.AtualizadoEm = DateTime.Now;
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
        orcamento.AtualizadoEm = DateTime.Now;
        _orcamentoRepository.Alterar(orcamento);
        
        if (await _orcamentoRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível reativar o Orçamento");
    }

    public Task Remover(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedDto<OrcamentoDto>> Buscar(BuscarOrcamentoDto dto)
    {
        var orcamentos = await _orcamentoRepository.Buscar(dto);
        return Mapper.Map<PagedDto<OrcamentoDto>>(orcamentos);
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
            orcamento.Foto = await _fileService.Upload(dto.Foto, EUploadPath.FotoOrcamento);
        }

        if (dto.Foto2 is { Length : > 0 })
        {
            orcamento.Foto2 = await _fileService.Upload(dto.Foto2, EUploadPath.FotoOrcamento);
        }

        if (dto.Foto3 is { Length : > 0 })
        {
            orcamento.Foto3 = await _fileService.Upload(dto.Foto3, EUploadPath.FotoOrcamento);
        }

        if (dto.Foto4 is { Length : > 0 })
        {
            orcamento.Foto4 = await _fileService.Upload(dto.Foto4, EUploadPath.FotoOrcamento);
        }

        if (dto.Foto5 is { Length : > 0 })
        {
            orcamento.Foto5 = await _fileService.Upload(dto.Foto5, EUploadPath.FotoOrcamento);
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