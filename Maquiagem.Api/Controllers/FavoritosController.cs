using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/favoritos")]
	[Tags("Favoritos")]
	public class FavoritosController : ControllerBase
	{
		private readonly IProdutoRepositorio _productRepositorio;

		public FavoritosController(IProdutoRepositorio productRepositorio)
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
