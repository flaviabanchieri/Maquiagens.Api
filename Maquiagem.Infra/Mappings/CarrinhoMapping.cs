using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Maquiagem.Infra.Mappings
{
	internal class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
	{
		public void Configure(EntityTypeBuilder<Carrinho> builder)
		{
			builder.HasKey(e => e.Id).IsClustered();

			builder.Property(e => e.Id)
				.IsRequired()
				.ValueGeneratedOnAdd().UseIdentityColumn();

			builder.Property(c => c.UsuarioId)
			.IsRequired();

			builder.Property(e => e.ProdutoId)
			.IsRequired();

			builder.Property(e => e.Quantidade)
			.IsRequired();

			builder.Property(e => e.CorEscolhidaHex)
			.IsRequired();

			builder.HasOne(c => c.Usuario)
			   .WithMany() 
			   .HasForeignKey(c => c.UsuarioId)
			   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(c => c.Produto)
				.WithMany()
				.HasForeignKey(c => c.ProdutoId)
				.OnDelete(DeleteBehavior.Cascade);


			builder.Property(c => c.DataCriacao).IsRequired();

			builder.ToTable("Carrinho", "dbo");
		}
	}
}
