using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Maquiagem.Infra.Data
{
	public class MaquiagemDbContext : DbContext
	{

		public MaquiagemDbContext(DbContextOptions<MaquiagemDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaquiagemDbContext).Assembly);
			ConfigurarColunasPadroes(modelBuilder);
		}

		private static void ConfigurarColunasPadroes(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<ValidationResult>();

			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
								e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
			{
				var varcharMax = property.GetMaxLength() == null;

				if (!varcharMax)
					property.SetColumnType("varchar(100)");
			}
		}
	}
}
