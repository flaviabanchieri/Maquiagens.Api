using Maquiagem.Application.DTOs.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductDto>> ObterProdutos(ProdutosFiltroDto filtro);
	}
}
