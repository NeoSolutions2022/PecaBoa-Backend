using Microsoft.AspNetCore.Mvc;
using PecaBoa.Api.Responses;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Application.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Gerencia;

public class GruposAcessoController : MainController
{
    private readonly IGrupoAcessoService _grupoAcessoService;
    private readonly IUsuarioService _usuarioService;
    public GruposAcessoController(INotificator notificator, IGrupoAcessoService grupoAcessoService, IUsuarioService usuarioService) : base(notificator)
    {
        _grupoAcessoService = grupoAcessoService;
        _usuarioService = usuarioService;
    }
    
    [HttpGet("{id}")]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Read)]
    [SwaggerOperation(Summary = "Obter um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(typeof(GrupoAcessoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId( int id)
    {
        var grupoAcesso = await _grupoAcessoService.ObterPorId(id);
        return OkResponse(grupoAcesso);
    }

    [HttpGet]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Read)]
    [SwaggerOperation(Summary = "Buscar um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(typeof(PagedDto<GrupoAcessoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<PagedDto<GrupoAcessoDto>> Buscar([FromQuery] BuscarGrupoAcessoDto dto)
    {
        return await _grupoAcessoService.Buscar(dto);
    }
    
    [HttpPost]
    //[ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Write)]
    [SwaggerOperation(Summary = "Adicionar de um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(typeof(GrupoAcessoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Adicionar([FromBody] CadastrarGrupoAcessoDto dto)
    {
        var grupoAcesso = await _grupoAcessoService.Cadastrar(dto);
        return CreatedResponse(string.Empty, grupoAcesso);
    }
    
    [HttpPut("{id}")]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Write)]
    [SwaggerOperation(Summary = "Alterar um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(typeof(GrupoAcessoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Alterar(int id, [FromBody] AlterarGrupoAcessoDto dto)
    {
        var grupoAcesso = await _grupoAcessoService.Alterar(id, dto);
        return OkResponse(grupoAcesso);
    }
    
    [HttpDelete("{id}")]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Delete)]
    [SwaggerOperation(Summary = "Desativar um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _grupoAcessoService.Desativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch("{id}/reativar")]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Write)]
    [SwaggerOperation(Summary = "Reativar um grupo de acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Reativar(int id)
    {
        await _grupoAcessoService.Reativar(id);
        return NoContentResponse();
    }
    
    [HttpPatch()]
    // [ClaimsAuthorize(PermissoesBackend.ConfiguracoesGruposAcesso, EPermissaoTipo.Write)]
    [SwaggerOperation(Summary = "Adicionar usuario ao Grupo de Acesso.", Tags = new [] { "Configurações - Grupos de acesso" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarUsuarioAoGrupoAcesso(AdicionarUsuarioGrupoAcessoDto usuarioGrupoAcessoDto)
    {
        await _usuarioService.AdicionarUsuarioGrupoAcesso(usuarioGrupoAcessoDto);
        return NoContentResponse();
    }

}