using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Compras.ComprasItens;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Maquiagem.Domain.Entidades;
using AutoMapper;
using Maquiagem.Application.Interfaces;
using Maquiagem.Application.DTOs.Compras;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/compras")]
	[Tags("Compras")]
	public class ComprasController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProdutoRepositorio _productRepositorio;
		private readonly IUsuarioContextService _usuarioContextService;
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		private readonly ICompraRepositorio _compraRepositorio;
		private readonly ICarrinhoRepositorio _carrinhoRepositorio;
		private readonly IUnitOfWork _unitOfWork;

		public ComprasController(IProdutoRepositorio productRepositorio, IUsuarioContextService usuarioContextService, IUsuarioRepositorio usuarioRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ICompraRepositorio compraRepositorio, ICarrinhoRepositorio carrinhoRepositorio)
		{
			_productRepositorio = productRepositorio;
			_usuarioContextService = usuarioContextService;
			_usuarioRepositorio = usuarioRepositorio;
			_unitOfWork=unitOfWork;
			_mapper = mapper;
			_compraRepositorio=compraRepositorio;
			_carrinhoRepositorio=carrinhoRepositorio;
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
		public async Task<IActionResult> Post([FromBody] ComprasDto dto)
		{
			var usuarioId = _usuarioContextService.PegarUsuarioIdLogado();
			if (usuarioId == 0)
				return Unauthorized();
			List<CompraItem> comprasItens = new();
			foreach (var item in dto.Carrinho)
			{
				CompraItem compraItem = new CompraItem(item.Produto.Id, usuarioId, item.Quantidade, item.CorEscolhidaHex);
				comprasItens.Add(compraItem);
			}

			Compra compra = new Compra(usuarioId, dto.MetodoPagamento, comprasItens);
			var carrinho = await _carrinhoRepositorio.ObterPorUsuarioId(usuarioId);
			_carrinhoRepositorio.RemoverMutiplos(carrinho);
			await _compraRepositorio.AdicionarAsync(compra);
			var commitResult = _unitOfWork.Commit();
			if (!commitResult.Success)
				return BadRequest();

			var retorno = _mapper.Map<ComprasDto>(compra);
			return Ok(retorno);

		}
	}
}
