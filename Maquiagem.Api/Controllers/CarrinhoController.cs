using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Services.Externo;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/carrinho")]
	[Tags("Carrinho")]
	public class CarrinhoController : ControllerBase
	{
		private readonly IProductRepositorio _productRepositorio;

		public CarrinhoController(IProductRepositorio productRepositorio)
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
