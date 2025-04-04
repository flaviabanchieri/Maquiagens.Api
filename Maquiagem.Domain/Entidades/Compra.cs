using Maquiagem.Application.DTOs.Compras.ComprasItens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Entidades
{
	public class Compra : EntityBase<Compra>
	{
		public int UsuarioId { get; private set; }
		public int MetodoPagamento { get; private set; }
		public Usuario Usuario { get; private set; }
		public List<CompraItem> ComprasItens { get; private set; } = new();

		public Compra() { }
		public Compra(int usuarioId, int metodoPagamento, List<CompraItem> itens)
		{
			UsuarioId = usuarioId;
			MetodoPagamento = metodoPagamento;
			ComprasItens.AddRange(itens);
		}

		public void EditarPagamento(int metodoPagamento)
		{
			MetodoPagamento = metodoPagamento;
		}
	}
}
