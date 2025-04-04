using Maquiagem.Application.DTOs.Compras;
using Maquiagem.Domain.Entidades;

namespace Maquiagem.Domain.Interfaces
{
	public interface ICompraRepositorio : IRepositorioBase<Compra>
	{
		Task<List<Compra>> ObterPorUsuarioId(int Id);
		ComprasDto ObterPorIdParaPagamento(int Id);
	}
}
