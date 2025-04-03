using Maquiagem.Application.DTOs.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Carrinho
{
	public class CarrinhoDto
	{
		public int ProdutoId { get; set; }
		public int UsuarioId { get; set; }
		public ProductDto Produto { get; set; }
	}
}
