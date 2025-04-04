using Maquiagem.Application.DTOs.Produtos;

namespace Maquiagem.Application.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductDto>> ObterProdutos(ProdutosFiltroDto filtro);
	}
}
