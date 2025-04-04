using AutoMapper;
using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Compras;
using Maquiagem.Application.DTOs.Compras.ComprasItens;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Entidades;

namespace IntegradorAnuncios.Api.Mapper
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Produto, ProductDto>();
            CreateMap<CorProduto, CorProduto>();
            CreateMap<Carrinho, CarrinhoDto>();
            CreateMap<Compra, ComprasDto>().ReverseMap();
            CreateMap<CompraItem, ComprasItensDto>();
        }
    }
}