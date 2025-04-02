using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maquiagem.Domain.Entidades;

namespace Maquiagem.Infra.Mappings
{
	internal class UsuarioMapping : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasKey(e => e.Id).IsClustered();

			builder.Property(e => e.Id)
				.IsRequired()
				.ValueGeneratedOnAdd().UseIdentityColumn();

			builder.Property(c => c.Nome)
			.IsRequired();

			builder.Property(e => e.Email)
			.IsRequired();

			builder.Property(e => e.Senha)
				.IsRequired();

			builder.Property(c => c.DataCriacao).IsRequired();

			builder.ToTable("Usuario", "dbo");
		}
	}
}
