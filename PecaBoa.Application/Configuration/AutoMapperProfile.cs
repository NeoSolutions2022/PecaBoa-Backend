using AutoMapper;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Entities;
using PecaBoa.Domain.Paginacao;

namespace PecaBoa.Application.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Administrador

        CreateMap<PecaBoa.Application.Dtos.V1.Administrador.AdministradorDto, Administrador>().ReverseMap();
        CreateMap<PecaBoa.Application.Dtos.V1.Administrador.AdicionarAdministradorDto, Administrador>()
            .ReverseMap();
        CreateMap<PecaBoa.Application.Dtos.V1.Administrador.AlterarAdministradorDto, Administrador>().ReverseMap();
        CreateMap<PagedDto<PecaBoa.Application.Dtos.V1.Administrador.AdministradorDto>,
            ResultadoPaginado<Administrador>>().ReverseMap();

        #endregion

        #region Usuario

        CreateMap<PecaBoa.Application.Dtos.V1.Usuario.UsuarioDto, Usuario>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Usuario.AlterarUsuarioDto, Usuario>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Usuario.CadastrarUsuarioDto, Usuario>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PagedDto<PecaBoa.Application.Dtos.V1.Usuario.UsuarioDto>, ResultadoPaginado<Usuario>>()
            .ReverseMap();

        #endregion

        #region Fornecedor

        CreateMap<PecaBoa.Application.Dtos.V1.Fornecedor.FornecedorDto, Fornecedor>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Fornecedor.AlterarFornecedorDto, Fornecedor>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Fornecedor.CadastrarFornecedorDto, Fornecedor>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PagedDto<PecaBoa.Application.Dtos.V1.Fornecedor.FornecedorDto>, ResultadoPaginado<Fornecedor>>()
            .ReverseMap();

        #endregion

        #region Produto-Servico

        CreateMap<ProdutoServico, PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoDto>()
            .ReverseMap();
        CreateMap<ProdutoServico, PecaBoa.Application.Dtos.V1.ProdutoServico.CadastrarProdutoServicoDto>()
            .ReverseMap();
        CreateMap<ProdutoServico, PecaBoa.Application.Dtos.V1.ProdutoServico.AlterarProdutoServicoDto>()
            .ReverseMap();
        CreateMap<ResultadoPaginado<ProdutoServico>,
                PagedDto<PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoDto>>()
            .ReverseMap();

        #endregion

        #region ProdutoServicoCaracteristica

        CreateMap<ProdutoServicoCaracteristica, PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoCaracteristica.ProdutoServicoCaracteristicaDto>().ReverseMap();
        CreateMap<ProdutoServicoCaracteristica, PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoCaracteristica.AdicionarProdutoServicoCaracteristicaDto>().ReverseMap();
        CreateMap<ProdutoServicoCaracteristica, PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoCaracteristica.AlterarProdutoServicoCaracteristicaDto>().ReverseMap();

        #endregion
    }
}