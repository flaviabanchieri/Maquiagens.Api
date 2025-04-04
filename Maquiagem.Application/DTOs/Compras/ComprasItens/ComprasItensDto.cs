using Maquiagem.Application.DTOs.Produtos;

namespace Maquiagem.Application.DTOs.Compras.ComprasItens
{
	public class ComprasItensDto
	{
		public int CompraId { get; set; }
		public int ProdutoId { get; set; }
		public int UsuarioId { get; set; }
		public int Quantidade { get; set; }
		public ProductDto Produto { get; set; }
		public List<string> CorEscolhidaHex { get; set; }
	}
}
