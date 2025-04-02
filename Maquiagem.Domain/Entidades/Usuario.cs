using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class Usuario : EntityBase<Usuario>
	{
		public required string Nome { get; set; }
		public required string Email { get; set; }
		public required string Senha { get; set; }
		public ICollection<Carrinho> Carrinho { get; set; } 
		public ICollection<Compra> Compras { get; set; } 
		
	}
}
