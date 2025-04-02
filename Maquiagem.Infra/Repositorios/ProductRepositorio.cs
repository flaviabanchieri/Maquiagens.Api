using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Repositorios
{
	public class ProductRepositorio : RepositorioBase<Product>, IProductRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public ProductRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public Task<Product> GetById(long id)
		{
			throw new NotImplementedException();
		}
	}
}