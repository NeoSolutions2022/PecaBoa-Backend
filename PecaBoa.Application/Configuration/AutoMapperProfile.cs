using AutoMapper;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;
using PecaBoa.Application.Dtos.V1.Usuario.Marca;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;
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

        #region Lojista

        CreateMap<PecaBoa.Application.Dtos.V1.Lojista.LojistaDto, Lojista>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Lojista.AlterarLojistaDto, Lojista>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PecaBoa.Application.Dtos.V1.Lojista.CadastrarLojistaDto, Lojista>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PagedDto<PecaBoa.Application.Dtos.V1.Lojista.LojistaDto>, ResultadoPaginado<Lojista>>()
            .ReverseMap();

        CreateMap<StatusDto, Status>().ReverseMap();

        CreateMap<CondicaoPecaDto, CondicaoPeca>();

        CreateMap<CategoriaVeiculoDto, CategoriaVeiculo>();

        CreateMap<MarcaDto, Marca>();
        
        #endregion

        #region Pedido

        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.PedidoDto>()
            .ReverseMap();
        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.CadastrarPedidoDto>()
            .ReverseMap();
        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.AlterarPedidoDto>()
            .ReverseMap();
        CreateMap<ResultadoPaginado<Pedido>,
                PagedDto<PecaBoa.Application.Dtos.V1.Pedido.PedidoDto>>()
            .ReverseMap();

        CreateMap<TipoDePeca, TipoDePecaDto>()
            .ReverseMap();

        #endregion

        #region Orcamento

        CreateMap<Orcamento, OrcamentoDto>()
            .ReverseMap();
        CreateMap<Orcamento, CadastrarOrcamentoDto>()
            .ReverseMap();
        CreateMap<OrcamentoDto, AlterarOrcamentoDto>()
            .ReverseMap();
        CreateMap<ResultadoPaginado<Orcamento>, PagedDto<OrcamentoDto>>();

        #endregion
    }
}