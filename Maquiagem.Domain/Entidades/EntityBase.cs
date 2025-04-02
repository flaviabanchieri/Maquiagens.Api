using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Maquiagem.Domain.Entidades
{
	public abstract class EntityBase<TEntity> : AbstractValidator<TEntity> where TEntity : EntityBase<TEntity>
	{
		public long Id { get; set; }
		public DateTime DataCriacao { get; set; }

	}
}