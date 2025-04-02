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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductColor, ProductColor>();
            CreateMap<Carrinho, CarrinhoDto>();
            CreateMap<Compra, ComprasDto>();
            CreateMap<CompraItem, ComprasItensDto>();
        }
    }
}