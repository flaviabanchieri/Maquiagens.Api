using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Interfaces
{
	public interface IProductRepositorio : IRepositorioBase<long, Product>
	{
		Task<Product> GetById(long id);
	}
}
