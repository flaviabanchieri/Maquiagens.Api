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

		[HttpGet("brands")]
		public IActionResult GetBrands()
		{
			return Ok(ConstantesDeProduto.Brands.OrderBy(b => b));
		}

		[HttpGet("tags")]
		public IActionResult GetTags()
		{
			return Ok(ConstantesDeProduto.Tags);
		}
	}
}
