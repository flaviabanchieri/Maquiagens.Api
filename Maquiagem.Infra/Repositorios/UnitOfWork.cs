using Maquiagem.Application.Interfaces;
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
	public class UnitOfWork : RepositorioBase<Usuario>, IUnitOfWork
	{
		private readonly MaquiagemDbContext _context;

		public UnitOfWork(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
