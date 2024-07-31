using AutoMapper;
using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Application.Dtos.V1.Orcamento;
using PecaBoa.Application.Dtos.V1.Permissoes;
using PecaBoa.Application.Dtos.V1.Usuario;
using PecaBoa.Application.Dtos.V1.Usuario.CategoriaVeiculo;
using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;
using PecaBoa.Application.Dtos.V1.Usuario.Marca;
using PecaBoa.Application.Dtos.V1.Usuario.Modelo;
using PecaBoa.Application.Dtos.V1.Usuario.Status;
using PecaBoa.Application.Dtos.V1.Usuario.TipoDePeca;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Paginacao;
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
            .ForMember(dest => dest.GrupoAcessos, opt 
                => opt.MapFrom(src => src.GrupoAcessos))
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros())
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        CreateMap<PagedDto<PecaBoa.Application.Dtos.V1.Usuario.UsuarioDto>, ResultadoPaginado<Usuario>>()
            .ReverseMap();

        CreateMap<GrupoAcessoUsuarioDto, GrupoAcessoUsuario>()
            .ForMember(dest => dest.UsuarioId, opt
                => opt.MapFrom(src => src.GrupoAcessoId))
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

        CreateMap<CondicaoPecaDto, CondicaoPeca>().ReverseMap();

        CreateMap<CategoriaVeiculoDto, CategoriaVeiculo>().ReverseMap();

        CreateMap<MarcaDto, Marca>().ReverseMap();

        CreateMap<ModeloDto, Modelo>().ReverseMap();
        
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
        CreateMap<AlterarOrcamentoDto, Orcamento>()
            .ReverseMap();

        #endregion
        
        #region GrupoAcesso

        CreateMap<GrupoAcesso, GrupoAcessoDto>().ReverseMap();
        CreateMap<GrupoAcesso, CadastrarGrupoAcessoDto>().ReverseMap();
        CreateMap<GrupoAcesso, AlterarGrupoAcessoDto>().ReverseMap();
        CreateMap<ResultadoPaginado<GrupoAcesso>, PagedDto<GrupoAcessoDto>>().ReverseMap();
        
        CreateMap<GrupoAcessoPermissao, GrupoAcessoPermissaoDto>().ReverseMap();
        CreateMap<GrupoAcessoPermissao, ManterGrupoAcessoPermissaoDto>().ReverseMap();
        CreateMap<PagedDto<PermissaoDto>, ResultadoPaginado<Permissao>>()
            .ReverseMap();
        CreateMap<PermissaoDto, Permissao>()
            .ReverseMap();
        CreateMap<CadastrarPermissaoDto, Permissao>()
            .ReverseMap();
        CreateMap<AlterarPermissaoDto, Permissao>()
            .ReverseMap();

        #endregion
        
        #region LojistaCartaoDeCredito
        
        CreateMap<Dtos.V1.Lojista.LojistaCartoesDeCredito.LojistaCartaoDeCreditoDto, LojistaCartaoDeCredito>()
            .AfterMap((_, dest) => dest.Number = dest.Number.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Phone = dest.Phone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.CpfCnpj = dest.CpfCnpj.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.PostalCode = dest.PostalCode.SomenteNumeros()!)
            .ReverseMap();
        
        CreateMap<Dtos.V1.Lojista.LojistaCartoesDeCredito.CreateLojistaCartaoDeCreditoDto, LojistaCartaoDeCredito>()
            .AfterMap((_, dest) => dest.Number = dest.Number.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Phone = dest.Phone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.CpfCnpj = dest.CpfCnpj.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.PostalCode = dest.PostalCode.SomenteNumeros()!)
            .ReverseMap();
        
        CreateMap<Dtos.V1.Lojista.LojistaCartoesDeCredito.UpdateLojistaCartaoDeCreditoDto, LojistaCartaoDeCredito>()
            .AfterMap((_, dest) => dest.Number = dest.Number.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Phone = dest.Phone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.CpfCnpj = dest.CpfCnpj.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.PostalCode = dest.PostalCode.SomenteNumeros()!)
            .ReverseMap();
        
        CreateMap<Dtos.V1.Lojista.LojistaCartoesDeCredito.LojistaCartaoDeCreditoDto, ResultadoPaginado<LojistaCartaoDeCredito>>().ReverseMap();
        
        CreateMap<Dtos.V1.Base.PagedDto<Dtos.V1.Lojista.LojistaCartoesDeCredito.LojistaCartaoDeCreditoDto>, IResultadoPaginado<LojistaCartaoDeCredito>>().ReverseMap();
        
        #endregion
    }
}