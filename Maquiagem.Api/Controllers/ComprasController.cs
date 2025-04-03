using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/compras")]
	[Tags("Compras")]
	public class ComprasController : ControllerBase
	{
		private readonly IProductRepositorio _productRepositorio;

		public ComprasController(IProductRepositorio productRepositorio)
		{
			_productRepositorio = productRepositorio;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] ProdutosFiltroDto filtros)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CarrinhoDto dto)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
