using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maquiagem.Infra.Mappings
{
	internal class CompraMapping : IEntityTypeConfiguration<Compra>
	{
		public void Configure(EntityTypeBuilder<Compra> builder)
		{
			builder.HasKey(e => e.Id).IsClustered();

			builder.Property(e => e.Id)
				.IsRequired()
				.ValueGeneratedOnAdd().UseIdentityColumn();

			builder.Property(c => c.UsuarioId)
			.IsRequired();

			builder.Property(e => e.MetodoPagamento)
			.IsRequired();

			builder.Property(c => c.DataCriacao).IsRequired();

			builder
				.HasMany(c => c.ComprasItens)
				.WithOne(ci => ci.Compra)
				.HasForeignKey(ci => ci.CompraId)
				.OnDelete(DeleteBehavior.Cascade);


			builder.ToTable("Compra", "dbo");
		}
	}
}
