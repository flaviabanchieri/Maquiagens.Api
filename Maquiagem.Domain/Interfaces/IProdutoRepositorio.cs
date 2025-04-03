using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Interfaces
{
	public interface IProdutoRepositorio : IRepositorioBase<Produto>
	{
		Task<Produto> ObterPorProdutoId(int ProdutoId);
	}
}
