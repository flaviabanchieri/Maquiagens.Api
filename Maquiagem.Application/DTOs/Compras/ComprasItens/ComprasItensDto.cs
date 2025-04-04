using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Compras.ComprasItens
{
	public class ComprasItensDto
	{
		public int CompraId { get; private set; }
		public int ProdutoId { get; private set; }
		public int UsuarioId { get; private set; }
		public int Quantidade { get; private set; }
		public List<string> CorEscolhidaHex { get; private set; }
	}
}
