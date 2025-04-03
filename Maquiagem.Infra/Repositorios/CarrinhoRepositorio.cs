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
	public class CarrinhoRepositorio : RepositorioBase<Carrinho>, ICarrinhoRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public CarrinhoRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Carrinho>> ObterPorUsuarioId(int Id)
		{
			return _context.Set<Carrinho>().Where(c => c.UsuarioId == Id).Include(c => c.Produto).ToList();
		}
	}
}