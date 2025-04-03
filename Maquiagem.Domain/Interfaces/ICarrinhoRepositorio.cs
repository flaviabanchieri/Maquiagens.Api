using Maquiagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Interfaces
{
	public interface ICarrinhoRepositorio : IRepositorioBase<Carrinho>
	{
		Task<List<Carrinho>> ObterPorUsuarioId(int Id);
	}
}
