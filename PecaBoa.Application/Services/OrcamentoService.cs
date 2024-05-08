using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Notification;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Services;

public class OrcamentoService : BaseService, IOrcamentoService
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public OrcamentoService(IMapper mapper, INotificator notificator, IOrcamentoRepository orcamentoRepository) : base(mapper, notificator)
    {
        _orcamentoRepository = orcamentoRepository;
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
}