using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Services;

public class GrupoAcessoService : BaseService, IGrupoAcessoService
{
    private readonly IPermissaoRepository _permissaoRepository;
    private readonly IGrupoAcessoRepository _grupoAcessoRepository;
    private readonly HttpContextAccessor _httpContextAccessor;

    public GrupoAcessoService(IMapper mapper, INotificator notificator, IPermissaoRepository permissaoRepository,
        IGrupoAcessoRepository grupoAcessoRepository,
         IOptions<HttpContextAccessor> httpContextAccessor)
        : base(mapper, notificator)
    {
        _permissaoRepository = permissaoRepository;
        _grupoAcessoRepository = grupoAcessoRepository;
        _httpContextAccessor = httpContextAccessor.Value;
    }

    public async Task<PagedDto<GrupoAcessoDto>> Buscar(BuscarGrupoAcessoDto dto)
    {
        var grupoAcessos = await _grupoAcessoRepository.Buscar(dto);
        return Mapper.Map<PagedDto<GrupoAcessoDto>>(grupoAcessos);
    }

    public async Task<GrupoAcessoDto?> ObterPorId(int id)
    {
        var grupoAcesso = await ObterGrupoAcesso(id);
        return grupoAcesso != null ? Mapper.Map<GrupoAcessoDto>(grupoAcesso) : null;
    }

    public async Task<GrupoAcessoDto?> Cadastrar(CadastrarGrupoAcessoDto dto)
    {
        var grupoAcesso = Mapper.Map<GrupoAcesso>(dto);

        if (!await Validar(grupoAcesso))
        {
            return null;
        }

        _grupoAcessoRepository.Cadastrar(grupoAcesso);

        return await CommitChanges() ? Mapper.Map<GrupoAcessoDto>(grupoAcesso) : null;
    }

    public async Task<GrupoAcessoDto?> Alterar(int id, AlterarGrupoAcessoDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("IDs não conferem.");
            return null;
        }

        var grupoAcesso = await ObterGrupoAcesso(id);
        if (grupoAcesso == null)
        {
            return null;
        }

        Mapper.Map(dto, grupoAcesso);
        if (!await Validar(grupoAcesso))
        {
            return null;
        }

        _grupoAcessoRepository.Editar(grupoAcesso);

        return await CommitChanges() ? Mapper.Map<GrupoAcessoDto>(grupoAcesso) : null;
    }

    public Task<List<GrupoDeAcessoFiltroDto>> Filtrar(List<FiltragemGrupoDeAcessoDto> dto, List<GrupoAcesso>? agremiacoes = null, int tamanho = 0, int aux = 0)
    {
        throw new NotImplementedException();
    }

    public async Task Reativar(int id)
    {
        var grupoAcesso = await ObterGrupoAcesso(id);
        if (grupoAcesso == null)
        {
            return;
        }

        grupoAcesso.Desativado = false;
        _grupoAcessoRepository.Editar(grupoAcesso);
        await CommitChanges();
    }

    public async Task Desativar(int id)
    {
        var grupoAcesso = await ObterGrupoAcesso(id);
        if (grupoAcesso == null)
        {
            return;
        }

        if (grupoAcesso.Administrador)
        {
            Notificator.Handle("Não é possível desativar o Grupo de Acesso padrão de Administrador.");
            return;
        }

        grupoAcesso.Desativado = true;
        _grupoAcessoRepository.Editar(grupoAcesso);
        await CommitChanges();
    }

    public Task<List<GrupoDeAcessoFiltroDto>> Pesquisar(string valor)
    {
        throw new NotImplementedException();
    }

    public Task LimparFiltro()
    {
        throw new NotImplementedException();
    }


    private async Task<bool> Validar(GrupoAcesso grupoAcesso)
    {
        if (!grupoAcesso.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
        var existente = await _grupoAcessoRepository.FirstOrDefault(c
            => c.Nome == grupoAcesso.Nome && c.Descricao == grupoAcesso.Descricao && c.Id != grupoAcesso.Id);
        if (existente != null)
        {
            Notificator.Handle(
                $"Já existe um grupo {(existente.Desativado ? "desativado" : "ativo")} com o mesmo nome e tipo.");
        }

        var permissoesIds = grupoAcesso.Permissoes.Select(c => c.PermissaoId).Distinct();
        var countPermissoes = await _permissaoRepository.Count(p => permissoesIds.Contains(p.Id));
        if (permissoesIds.Count() != countPermissoes)
        {
            Notificator.Handle("Uma ou mais permissões são inválidas.");
        }

        return !Notificator.HasNotification;
    }

    private async Task<GrupoAcesso?> ObterGrupoAcesso(int id)
    {
        var grupoAcesso = await _grupoAcessoRepository.ObterPorId(id);
        if (grupoAcesso == null)
        {
            Notificator.HandleNotFoundResource();
        }

        return grupoAcesso;
    }

    private async Task<bool> CommitChanges()
    {
        if (await _grupoAcessoRepository.UnitOfWork.Commit()) return true;
        Notificator.Handle("Não foi possível salvar alterações!");
        return false;
    }

    private async Task<List<GrupoAcesso>> PossuiGrupoDeAcesso(string nomeParametro,
        List<GrupoAcesso>? gruposAcesso = null)
    {
        if (gruposAcesso == null)
        {
            gruposAcesso = await _grupoAcessoRepository.ObterTodos();
        }

        switch (nomeParametro)
        {
            case "Nome": return gruposAcesso.OrderBy(c => c.Nome).ToList();
            case "Descricao": return gruposAcesso.OrderBy(c => c.Descricao).ToList();
            default: return gruposAcesso.OrderBy(c => c.Id).ToList();
        }
    }
}