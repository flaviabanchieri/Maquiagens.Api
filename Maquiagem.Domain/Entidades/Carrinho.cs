namespace Maquiagem.Domain.Entidades
{
	public class Carrinho : EntityBase<Carrinho>
	{
		public int ProdutoId { get; private set; }
		public int UsuarioId { get; private set; }
		public int Quantidade { get; private set; }
		public List<string> CorEscolhidaHex { get; private set; }
		public Usuario Usuario { get; private set; }
		public Produto Produto {get; private set; }
		public Carrinho() {}

		public Carrinho(int produtoId, int usuarioId, int quantidade, List<string> corEscolhidaHex, Usuario usuario, Produto produto)
		{
			ProdutoId = produtoId;
			UsuarioId = usuarioId;
			Quantidade = quantidade;
			CorEscolhidaHex = corEscolhidaHex ?? new List<string>(); 
			Usuario = usuario;
			Produto = produto;
		}

		public void EditarCarrinho(int quantidade, List<string> corEscolhidaHex)
		{
			Quantidade = quantidade;
			CorEscolhidaHex = corEscolhidaHex ?? new List<string>(); 
		}
	}
}
