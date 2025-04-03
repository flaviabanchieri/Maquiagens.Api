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
				.IsRequired()
				.ValueGeneratedOnAdd()
				.UseIdentityColumn();

			builder.Property(e => e.Brand)
				.HasMaxLength(255);

			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(e => e.Price)
				.HasMaxLength(50);

			builder.Property(e => e.PriceSign)
				.HasMaxLength(10);

			builder.Property(e => e.Currency)
				.HasMaxLength(10);

			builder.Property(e => e.ImageLink)
				.HasMaxLength(500);

			builder.Property(e => e.ProductLink)
				.HasMaxLength(500);

			builder.Property(e => e.WebsiteLink)
				.HasMaxLength(500);

			builder.Property(e => e.Description)
				.HasColumnType("TEXT");

			builder.Property(e => e.Rating);

			builder.Property(e => e.Category)
				.HasMaxLength(100);

			builder.Property(e => e.ProductType)
				.HasMaxLength(100);

			builder.Property(e => e.ProductApiUrl)
				.HasMaxLength(500);

			builder.Property(e => e.ApiFeaturedImage)
				.HasMaxLength(500);

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