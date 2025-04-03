using Maquiagem.Application.DTOs.Auth;
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
		public int? Id { get; set; }
		public int Quantidade { get; set; }
		public ProductDto Produto { get; set; }
		public List<string> CorEscolhidaHex { get; set; }
	}
}
