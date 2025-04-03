using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Mappings
{
	internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.IsRequired();

			builder.Property(e => e.Brand)
				.IsRequired(false)
				.HasMaxLength(255);

			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(e => e.Price)
				.IsRequired(false)
				.HasMaxLength(50);

			builder.Property(e => e.PriceSign)
				.IsRequired(false)
				.HasMaxLength(10);

			builder.Property(e => e.Currency).IsRequired(false)
				.HasMaxLength(10);

			builder.Property(e => e.ImageLink).IsRequired(false);

			builder.Property(e => e.ProductLink).IsRequired(false);

			builder.Property(e => e.WebsiteLink).IsRequired(false);

			builder.Property(e => e.Description)
				.HasColumnType("TEXT");

			builder.Property(e => e.Rating).IsRequired(false);

			builder.Property(e => e.ProdutoId).IsRequired(false);

			builder.Property(e => e.Category).IsRequired(false)
				.HasMaxLength(100);

			builder.Property(e => e.ProductType).IsRequired(false)
				.HasMaxLength(100);

			builder.Property(e => e.ProductApiUrl).IsRequired(false);

			builder.Property(e => e.ApiFeaturedImage).IsRequired(false);

			builder.Property(e => e.CreatedAt)
				.HasColumnType("DATETIME");

			builder.Property(e => e.UpdatedAt)
				.HasColumnType("DATETIME");

			builder.OwnsMany(e => e.ProductColors, color =>
			{
				color.Property(c => c.HexValue);
				color.Property(c => c.ColourName).HasMaxLength(100);
			});

			builder.ToTable("Produto", "dbo");
		}
	}
}