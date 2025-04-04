using Maquiagem.Application.DTOs.Compras;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Repositorios
{
	public class CompraRepositorio : RepositorioBase<Compra>, ICompraRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public CompraRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Compra>> ObterPorUsuarioId(int Id)
		{
			return _context.Set<Compra>().Where(c => c.UsuarioId == Id).Include(c => c.ComprasItens).ThenInclude(i => i.Produto).ToList();
		}

		public ComprasDto ObterPorIdParaPagamento(int Id)
		{
			var compra = _context.Set<Compra>()
				.Where(c => c.Id == Id)
				.Include(c => c.ComprasItens)
					.ThenInclude(i => i.Produto)
				.FirstOrDefault();

			if (compra == null)
				return null;

			ComprasDto dto = new()
			{
				MetodoPagamento = compra.MetodoPagamento,
				ValorTotal = (double)compra.ComprasItens.Sum(item =>
					decimal.Parse(item.Produto.Price, System.Globalization.CultureInfo.InvariantCulture) * item.Quantidade)
			};

			return dto;
		}
	}
}