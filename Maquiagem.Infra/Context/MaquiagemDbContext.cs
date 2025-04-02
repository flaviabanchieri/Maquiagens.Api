using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Data
{
	public class MaquiagemDbContext : DbContext, IUnitOfWork
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

		public async Task<bool> Commit()
		{
			foreach (var entry in ChangeTracker.Entries()
				.Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
			{
				if (entry.State == EntityState.Added)
				{
					if (entry.Property("DataCriacao").CurrentValue == null || entry.Property("DataCriacao").CurrentValue as DateTime? == DateTime.MinValue)
						entry.Property("DataCriacao").CurrentValue = DateTime.Now;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataCriacao").IsModified = false;
				}
			}

			var sucesso = await base.SaveChangesAsync() > 0;

			return sucesso;
		}
	}
}
