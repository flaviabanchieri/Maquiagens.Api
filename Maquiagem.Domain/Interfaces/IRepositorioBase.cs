using Maquiagem.Application.Interfaces;
using System.Linq.Expressions;

namespace Maquiagem.Domain.Interfaces
{
	public interface IRepositorioBase<TEntity> : IDisposable
	{
		Task AdicionarAsync(TEntity obj);
		Task AdicionarMultiplosAsync(List<TEntity> lista);
		void Atualizar(TEntity obj);
		Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
		Task<IEnumerable<TEntity>> BuscarAsyncAsNoTracking(Expression<Func<TEntity, bool>> predicate);
		Task<IEnumerable<TEntity>> ListarAsync();
		Task<IEnumerable<TEntity>> ListarAsyncAsNoTracking();
		Task<TEntity> ObterPorIdAsync(int id);
		Task<TEntity> ObterPorIdAsyncAsNoTracking(int id);
		void Remover(TEntity obj);
		void RemoverMutiplos(List<TEntity> lista);
	}
}
