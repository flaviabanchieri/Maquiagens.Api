using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Mappings
{
	internal class CompraItensMapping : IEntityTypeConfiguration<CompraItem>
	{
		public void Configure(EntityTypeBuilder<CompraItem> builder)
		{
			builder.HasKey(e => e.Id).IsClustered();

			builder.Property(e => e.Id)
				.IsRequired()
				.ValueGeneratedOnAdd().UseIdentityColumn();

			builder.Property(c => c.CompraId)
			.IsRequired();

			builder.Property(e => e.ProdutoId) 
			.IsRequired();

			builder.Property(c => c.DataCriacao).IsRequired();

			builder.ToTable("CompraItem", "dbo");
		}
	}
}
