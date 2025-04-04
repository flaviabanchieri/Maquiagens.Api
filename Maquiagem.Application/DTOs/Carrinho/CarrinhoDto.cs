using Maquiagem.Application.DTOs.Produtos;

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
