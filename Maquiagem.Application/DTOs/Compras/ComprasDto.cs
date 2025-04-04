using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Compras.ComprasItens;

namespace Maquiagem.Application.DTOs.Compras
{
	public class ComprasDto
	{
		public int? Id { get; set; }
		public int UsuarioId { get; set; }
		public int MetodoPagamento { get; set; }
		public double? ValorTotal { get; set; }
		public DateTime DataCriacao { get; set; }
		public List<ComprasItensDto>? ComprasItens { get; set; } = new();
		public List<CarrinhoDto>? Carrinho { get; set; } = new();
	}
}
