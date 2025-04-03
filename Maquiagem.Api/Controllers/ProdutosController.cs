using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Application.Interfaces;
using Maquiagem.Application.Utils;
using Maquiagem.Domain.Entidades;
using Maquiagem.Infra.Services.Externo;
using Microsoft.AspNetCore.Mvc;

namespace Maquiagens.Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    [Tags("Produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProductService _productServices;

		public ProdutosController(IProductService productServices)
		{
			_productServices=productServices;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] ProdutosFiltroDto filtros)
		{
			try
			{
				var products = await _productServices.ObterProdutos(filtros);
				return Ok(products);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("Marcas")]
		public IActionResult ObterMarcas()
		{
			return Ok(ConstantesDeProduto.Brands.OrderBy(b => b));
		}

		[HttpGet("Tags")]
		public IActionResult ObterTags()
		{
			return Ok(ConstantesDeProduto.Tags);
		}

		[HttpGet("Categorias")]
		public IActionResult GetCategorias()
		{
			return Ok(ConstantesDeProduto.Categorias);
		}

		[HttpGet("Tipo")]
		public IActionResult GetTipos()
		{
			return Ok(ConstantesDeProduto.Tipo);
		}
	}
}
