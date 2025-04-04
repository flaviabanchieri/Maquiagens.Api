using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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


			builder.Property(e => e.Quantidade)
				.IsRequired();

			builder.Property(e => e.CorEscolhidaHex)
				.IsRequired();

			builder.HasOne(c => c.Usuario)
				.WithMany()
				.HasForeignKey(c => c.UsuarioId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(c => c.Produto)
				.WithMany()
				.HasForeignKey(c => c.ProdutoId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(c => c.Compra)
				.WithMany(c => c.ComprasItens)
				.HasForeignKey(c => c.CompraId)
				.OnDelete(DeleteBehavior.Restrict); 



			builder.Property(c => c.DataCriacao).IsRequired();

			builder.ToTable("CompraItem", "dbo");
		}
	}
}
