using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class CompraItem : EntityBase<CompraItem>
	{
		public int ProdutoId { get;set; }
		public int CompraId { get; set; }
		public required Compra Compra { get; set; }
	}
}
