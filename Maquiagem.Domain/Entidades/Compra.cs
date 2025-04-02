using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class Compra : EntityBase<Compra>
	{
		public int UsuarioId { get; set; }
		public int MetodoPagamento { get; set; }
		public required Usuario Usuario { get; set; }
	}
}
