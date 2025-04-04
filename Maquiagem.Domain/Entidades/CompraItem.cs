using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class CompraItem : EntityBase<CompraItem>
	{
		public int CompraId { get; private set; }
		public int ProdutoId { get; private set; }
		public int UsuarioId { get; private set; }
		public int Quantidade { get; private set; }
		public List<string> CorEscolhidaHex { get; private set; }
		public Usuario Usuario { get; private set; }
		public Produto Produto { get; private set; }
		public Compra Compra { get; private set; }
		public CompraItem() { }

		public CompraItem(int produtoId, int usuarioId, int quantidade, List<string> corEscolhidaHex)
		{
			ProdutoId = produtoId;
			UsuarioId = usuarioId;
			Quantidade = quantidade;
			CorEscolhidaHex = corEscolhidaHex ?? new List<string>();
		}
	}
}
