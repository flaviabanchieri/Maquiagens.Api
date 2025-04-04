using Maquiagem.Domain.Entidades;

namespace Maquiagem.Domain.Interfaces
{
	public interface ICarrinhoRepositorio : IRepositorioBase<Carrinho>
	{
		Task<List<Carrinho>> ObterPorUsuarioId(int Id);
	}
}
