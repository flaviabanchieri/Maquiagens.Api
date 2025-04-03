using Maquiagem.Application.DTOs.Produtos;
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
	public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public ProdutoRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Produto> ObterPorProdutoId(int ProdutoId)
		{
			return await _context.Set<Produto>().Where(p => p.ProdutoId == ProdutoId).FirstOrDefaultAsync();
		}
	}
}