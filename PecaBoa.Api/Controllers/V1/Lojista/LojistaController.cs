﻿using Microsoft.AspNetCore.Authorization;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Lojista;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;
using PecaBoa.Application.Dtos.V1.Lojista.Inscricoes;
using Swashbuckle.AspNetCore.Annotations;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[Route("v{version:apiVersion}/Lojista/[controller]")]
public class LojistaController : MainController
{
    private readonly ILojistaService _lojistaService;

    public LojistaController(INotificator notificator, ILojistaService lojistaService) : base(notificator)
    {
        _lojistaService = lojistaService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listagem de Lojista", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(PagedDto<LojistaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Buscar([FromQuery] BuscarLojistaDto dto)
    {
        var lojista = await _lojistaService.Buscar(dto);
        return OkResponse(lojista);
    }
    
    [HttpGet("anuncios-Lojistas")]
    [SwaggerOperation(Summary = "Listagem dos anúncios de Lojistaes", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(PagedDto<LojistaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> BuscarAnuncio()
    {
        var lojista = await _lojistaService.BuscarAnuncio();
        return OkResponse(lojista);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter um Lojista por Id.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var lojista = await _lojistaService.ObterPorId(id);
        return OkResponse(lojista);
    }

    [HttpGet("email/{email}")]
    [SwaggerOperation(Summary = "Obter um Lojista por Email.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorEmail(string email)
    {
        var lojista = await _lojistaService.ObterPorEmail(email);
        return OkResponse(lojista);
    }

    [HttpGet("cpf/{cpf}")]
    [SwaggerOperation(Summary = "Obter um Lojista por cpf.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorCpf(string cpf)
    {
        var lojista = await _lojistaService.ObterPorCpf(cpf);
        return OkResponse(lojista);
    }

    [HttpGet("cnpj/{cnpj}")]
    [SwaggerOperation(Summary = "Obter um Lojista por Cnpj.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorCnpj(string cnpj)
    {
        var lojista = await _lojistaService.ObterPorCnpj(cnpj);
        return OkResponse(lojista);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar um Lojista.", Tags = new[] { "Usuario - Lojista" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(typeof(LojistaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarLojistaDto dto)
    {
        var lojista = await _lojistaService.Alterar(id, dto);
        return OkResponse(lojista);
    }

    [HttpPatch("{id}/alterar-descricao")]
    [SwaggerOperation(Summary = "Alterar descrição.", Tags = new[] { "Usuario - Lojista" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AlterarDescricao(int id, [FromBody] string descricao)
    {
        await _lojistaService.AlterarDescricao(id, descricao);
        return OkResponse();
    }
    
    [HttpPost("{id}/alterar-senha")]
    [SwaggerOperation(Summary = "Enviar email para alterar a senha.", Tags = new[] { "Usuario - Lojista" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AlterarSenha(int id)
    {
        await _lojistaService.AlterarSenha(id);
        return OkResponse();
    }
    
    [HttpPatch("alterar-senha-sem-email")]
    [SwaggerOperation(Summary = "alterar a senha sem envio de Email.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AlterarSenhaSemEnvioEmail(AlterarSenhaLojistaSemEnvioEmailDto dto)
    {
        await _lojistaService.AlterarSenhaSemEnvioEmail(dto);
        return OkResponse();
    }
    
    [HttpPost("inscricao")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Criar a inscrição de um lojista.", Tags = new[] { "Usuario - Lojista" })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Inscricao([FromBody] CadastrarInscricaoDto dto)
    {
        await _lojistaService.Inscricao(dto);
        return OkResponse();
    }
    
    [HttpPost("hook")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Verify payment.", Tags = new[] { "User - Plan" })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> VerifyPayment([FromBody] SubscriptionHookDto dto)
    {
        await _lojistaService.VerifyPayment(dto);
        return OkResponse("");
    }
    
    [HttpPatch("alterar-foto")]
    [SwaggerOperation(Summary = "Alterar a foto do Lojista.",
        Tags = new[] { "Usuario - Lojista" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AlterarFoto([FromForm] AlterarFotoLojistaDto dto)
    {
        await _lojistaService.AlterarFoto(dto);
        return NoContentResponse();
    }

    [HttpPatch("remover-foto")]
    [SwaggerOperation(Summary = "Remover a foto do Lojista.",
        Tags = new[] { "Usuario - Lojista" })]
    [ClaimsAuthorize("Lojista", ETipoUsuario.Lojista)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoverFoto()
    {
        await _lojistaService.RemoverFoto();
        return NoContentResponse();
    }
}