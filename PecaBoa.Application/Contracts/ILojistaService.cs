﻿using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Lojista;

namespace PecaBoa.Application.Contracts;

public interface ILojistaService
{
    Task<PagedDto<LojistaDto>> Buscar(BuscarLojistaDto dto);
    Task<PagedDto<LojistaDto>> BuscarAnuncio();
    Task<LojistaDto?> Cadastrar(CadastrarLojistaDto dto);
    Task<LojistaDto?> Alterar(int id, AlterarLojistaDto dto);
    Task<LojistaDto?> ObterPorId(int id);
    Task<LojistaDto?> ObterPorEmail(string email);
    Task<LojistaDto?> ObterPorCnpj(string cnpj);
    Task<LojistaDto?> ObterPorCpf(string cpf);
    Task AlterarSenha(int id);
    Task Desativar(int id);
    Task AlterarDescricao(int id, string descricao);
    Task Reativar(int id);
    Task AtivarAnuncio(int id);
    Task DesativarAnuncio(int id);
    Task Remover(int id);
}