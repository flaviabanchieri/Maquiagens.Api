using Maquiagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Interfaces
{
	public interface ICompraRepositorio : IRepositorioBase<Compra>
	{
		Task<List<Compra>> ObterPorUsuarioId(int Id);
	}
}
