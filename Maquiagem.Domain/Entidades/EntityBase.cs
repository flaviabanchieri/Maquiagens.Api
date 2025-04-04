namespace Maquiagem.Domain.Entidades
{
	public abstract class EntityBase<TEntity>
	{
		public int Id { get; set; }
		public DateTime DataCriacao { get; set; } = DateTime.Now;

	}
}