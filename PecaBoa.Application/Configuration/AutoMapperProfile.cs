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

        #endregion

        #region Produto-Servico

        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.PedidoDto>()
            .ReverseMap();
        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.CadastrarPedidoDto>()
            .ReverseMap();
        CreateMap<Pedido, PecaBoa.Application.Dtos.V1.Pedido.AlterarPedidoDto>()
            .ReverseMap();
        CreateMap<ResultadoPaginado<Pedido>,
                PagedDto<PecaBoa.Application.Dtos.V1.Pedido.PedidoDto>>()
            .ReverseMap();

        #endregion

        #region PedidoCaracteristica

        CreateMap<PedidoCaracteristica, PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica.PedidoCaracteristicaDto>().ReverseMap();
        CreateMap<PedidoCaracteristica, PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica.AdicionarPedidoCaracteristicaDto>().ReverseMap();
        CreateMap<PedidoCaracteristica, PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica.AlterarPedidoCaracteristicaDto>().ReverseMap();

        #endregion
    }
}