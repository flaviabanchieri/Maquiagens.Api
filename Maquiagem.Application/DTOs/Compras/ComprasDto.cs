using Maquiagem.Application.DTOs.Compras.ComprasItens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Compras
{
	public class ComprasDto
	{
		public int UsuarioId { get; set; }
		public int MetodoPagamento { get; set; }
		public List<ComprasItensDto> ComprasItens { get; set; } = new();
	}
}
