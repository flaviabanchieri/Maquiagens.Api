using Maquiagem.Domain.Interfaces;
using Maquiagem.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Maquiagem.Infra.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Maquiagem.Application.Interfaces;

namespace Maquiagem.Infra.Repositorios
{
	public class RepositorioBase<TEntity> : IRepositorioBase<TEntity>
		where TEntity : EntityBase<TEntity>
	{
		private readonly DbSet<TEntity> _dbSet;
		private readonly MaquiagemDbContext _context;

		public RepositorioBase(DbContext context)
		{
			_dbSet = context.Set<TEntity>();
			_context = (MaquiagemDbContext)context;
		}

		public async Task AdicionarAsync(TEntity obj) => await _dbSet.AddAsync(obj);

		public async Task AdicionarMultiplosAsync(List<TEntity> lista) => await _dbSet.AddRangeAsync(lista);

		public void Adicionar(TEntity obj) => _dbSet.Add(obj);

		public void Atualizar(TEntity obj) => _dbSet.Update(obj);

		public void Remover(TEntity obj) => _dbSet.Remove(obj);

		public void RemoverMutiplos(List<TEntity> lista) => _dbSet.RemoveRange(lista);

		public async Task<IEnumerable<TEntity>> ListarAsyncAsNoTracking() => await _dbSet.AsNoTracking().ToListAsync();

		public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate) =>
			await _dbSet.Where(predicate).ToListAsync();

		public async Task<IEnumerable<TEntity>> BuscarAsyncAsNoTracking(Expression<Func<TEntity, bool>> predicate) =>
			await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

		public async Task<TEntity> ObterPorIdAsyncAsNoTracking(int id) =>
			await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

		public async Task<IEnumerable<TEntity>> ListarAsync() => await _dbSet.ToListAsync();

		public async Task<TEntity> ObterPorIdAsync(int id) =>
			await _dbSet.FindAsync(id);

		public void Dispose() => _context?.Dispose();
	}
}
