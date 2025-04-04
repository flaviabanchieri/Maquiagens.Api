using Maquiagem.Domain.Entidades;

namespace Maquiagem.Domain.Interfaces
{
	public interface IProdutoRepositorio : IRepositorioBase<Produto>
	{
		Task<Produto> ObterPorProdutoId(int ProdutoId);
	}
}
