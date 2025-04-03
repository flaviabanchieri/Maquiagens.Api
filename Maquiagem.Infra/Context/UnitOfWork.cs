using Maquiagem.Application.Interfaces;
using Maquiagem.Application.Utils;
using Maquiagem.Infra.Data;
using System.Diagnostics;

namespace Maquiagem.Infra.Context
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MaquiagemDbContext _context;

		public UnitOfWork(MaquiagemDbContext context)
		{
			_context = context;
		}

		public void Dispose()
		{ }

		public CommandResponse Commit()
		{
			try
			{
				_context.SaveChanges();
				return new CommandResponse(true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return new CommandResponse(false);
			}
		}
	}
}