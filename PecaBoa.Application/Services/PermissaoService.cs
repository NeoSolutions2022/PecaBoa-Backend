using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Application.Dtos.V1.Permissoes;
using PecaBoa.Application.Notification;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Services;

public class PermissaoService : BaseService, IPermissaoService
{
    private readonly IPermissaoRepository _permissaoRepository;

    public PermissaoService(IMapper mapper, INotificator notificator, IPermissaoRepository permissaoRepository) : base(mapper, notificator)
    {
        _permissaoRepository = permissaoRepository;
    }

    public async Task<PagedDto<PermissaoDto>> Buscar(BuscarPermissaoDto dto)
    {
        var permissoes = await _permissaoRepository.Buscar(dto);
        return Mapper.Map<PagedDto<PermissaoDto>>(permissoes);
    }

    public async Task<PermissaoDto?> ObterPorId(int id)
    {
        var permissao = await ObterPermissao(id);
        return permissao != null ? Mapper.Map<PermissaoDto>(permissao) : null;
    }
    
    public async Task<PermissaoDto?> Adicionar(CadastrarPermissaoDto dto)
    {
        var permissao = Mapper.Map<Permissao>(dto);
        if (!await Validar(permissao))
        {
            return null;
        }
        
        _permissaoRepository.Cadastrar(permissao);

        return await CommitChanges() ? Mapper.Map<PermissaoDto>(permissao) : null;
    }
    
    public async Task<PermissaoDto?> Alterar(int id, AlterarPermissaoDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("IDs não conferem.");
            return null;
        }

        var permissao = await ObterPermissao(id);
        if (permissao == null)
        {
            return null;
        }
        
        Mapper.Map(dto, permissao);
        if (!await Validar(permissao))
        {
            return null;
        }

        _permissaoRepository.Alterar(permissao);
        return await CommitChanges() ? Mapper.Map<PermissaoDto>(permissao) : null;
    }

    public async Task Deletar(int id)
    {
        var permissao = await ObterPermissao(id);
        if (permissao == null)
        {
            return;
        }
        
        if (await _permissaoRepository.Any(c => c.Grupos.Any(i => i.PermissaoId == id)))
        {
            Notificator.Handle("Há grupos associados a esta permissão, não será possível deletá-la.");
            return;
        }
        
        _permissaoRepository.Deletar(permissao);
        await CommitChanges();
    }

    private async Task<Permissao?> ObterPermissao(int id)
    {
        var permissao = await _permissaoRepository.ObterPorId(id);
        if (permissao == null)
        {
            Notificator.HandleNotFoundResource();
        }
        
        return permissao;
    }
    
    private async Task<bool> Validar(Permissao permissao)
    {
        if (!permissao.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var existente = await _permissaoRepository.FirstOrDefault(
            c => c.Nome == permissao.Nome && c.Categoria == permissao.Categoria && c.Id != permissao.Id);
        if (existente != null)
        {
            Notificator.Handle($"Já existe uma permissão com o mesmo nome e categoria.");
        }

        return !Notificator.HasNotification;
    }
    
    private async Task<bool> CommitChanges()
    {
        if (await _permissaoRepository.UnitOfWork.Commit())
        {
            return true;
        }
        
        Notificator.Handle("Não foi possível salvar as alterações.");
        return false;
    }
}