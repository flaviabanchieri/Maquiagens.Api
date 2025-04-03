using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class Carrinho : EntityBase<Carrinho>
	{
		public int ProdutoId { get; set; }
		public int UsuarioId { get; set; }
		public int Quantidade { get; set; }
		public List<string> CorEscolhidaHex { get; set;}
		public Usuario Usuario { get; set; }
		public Produto Produto {get; set; }
	}
}
