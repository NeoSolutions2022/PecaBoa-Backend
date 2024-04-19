using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Fornecedor;

namespace PecaBoa.Application.Contracts;

public interface IFornecedorService
{
    Task<PagedDto<FornecedorDto>> Buscar(BuscarFornecedorDto dto);
    Task<PagedDto<FornecedorDto>> BuscarAnuncio();
    Task<FornecedorDto?> Cadastrar(CadastrarFornecedorDto dto);
    Task<FornecedorDto?> Alterar(int id, AlterarFornecedorDto dto);
    Task<FornecedorDto?> ObterPorId(int id);
    Task<FornecedorDto?> ObterPorEmail(string email);
    Task<FornecedorDto?> ObterPorCnpj(string cnpj);
    Task<FornecedorDto?> ObterPorCpf(string cpf);
    Task AlterarSenha(int id);
    Task Desativar(int id);
    Task AlterarDescricao(int id, string descricao);
    
    Task AlterarFoto(int id, AlterarFotoFornecedorDto foto);
    Task Reativar(int id);
    Task AtivarAnuncio(int id);
    Task DesativarAnuncio(int id);
    Task Remover(int id);
}