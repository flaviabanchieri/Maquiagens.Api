using AutoMapper;
using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.DTOs.Carrinho;
using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Context;
using Maquiagem.Infra.Services;
using Maquiagem.Infra.Services.Externo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Maquiagem.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/carrinho")]
	[Tags("Carrinho")]
	public class CarrinhoController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProdutoRepositorio _productRepositorio;
		private readonly IUsuarioContextService _usuarioContextService;
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		private readonly ICarrinhoRepositorio _carrinhoRepositorio; 
		private readonly IUnitOfWork _unitOfWork; 

		public CarrinhoController(IProdutoRepositorio productRepositorio, IUsuarioContextService usuarioContextService, IUsuarioRepositorio usuarioRepositorio, ICarrinhoRepositorio carrinhoRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_productRepositorio = productRepositorio;
			_usuarioContextService = usuarioContextService;
			_usuarioRepositorio = usuarioRepositorio;
			_carrinhoRepositorio = carrinhoRepositorio;
			_unitOfWork=unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var usuarioId = _usuarioContextService.PegarUsuarioIdLogado();
				var carrinho = await _carrinhoRepositorio.ObterPorUsuarioId(usuarioId);
				var resultado = _mapper.Map<List<CarrinhoDto>>(carrinho);
				return Ok(resultado);
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
				Carrinho carrinho = new();
				var usuarioId = _usuarioContextService.PegarUsuarioIdLogado();
				Usuario usuario = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);
				Produto produto = await _productRepositorio.ObterPorProdutoId(dto.Produto.Id);

				if(produto == null)
				{
					produto = new Produto(
						dto.Produto.Brand,
						dto.Produto.Name,
						dto.Produto.Price,
						dto.Produto.PriceSign,
						dto.Produto.Currency,
						dto.Produto.ImageLink,
						dto.Produto.ProductLink,
						dto.Produto.WebsiteLink,
						dto.Produto.Description,
						dto.Produto.Category,
						dto.Produto.ProductType,
						dto.Produto.TagList ?? new List<string>(),
						dto.Produto.CreatedAt,
						dto.Produto.UpdatedAt,
						dto.Produto.ProductApiUrl,
						dto.Produto.ApiFeaturedImage,
						dto.Produto.Id
					);

				}

				carrinho = new Carrinho(
					dto.Produto.Id,
					usuarioId,
					dto.Quantidade,
					dto.CorEscolhidaHex,
					usuario,
					produto
				);

				await _carrinhoRepositorio.AdicionarAsync( carrinho );
				var commitResult = _unitOfWork.Commit();
				return Ok(commitResult.Success);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("editar")]
		public async Task<IActionResult> Editar([FromBody]CarrinhoDto dto)
		{
			try
			{
				var carrinho = await _carrinhoRepositorio.ObterPorIdAsync((int)dto.Id);

				if (carrinho == null)
					return NotFound(new { mensagem = "Carrinho não encontrado" });

				carrinho.EditarCarrinho(dto.Quantidade, dto.CorEscolhidaHex);
				_carrinhoRepositorio.Atualizar(carrinho);

				var commitResult = _unitOfWork.Commit();
				return Ok(commitResult.Success);
			}
			catch (Exception ex)
			{
				return BadRequest(new { mensagem = "Ocorreu um erro ao editar o carrinho.", erro = ex.Message });
			}
		}

		[HttpDelete("deletar/{id}")]
		public async Task<IActionResult> Apagar(int id)
		{
			try
			{
				var carrinho = await _carrinhoRepositorio.ObterPorIdAsync(id);

				if (carrinho == null)
					return NotFound(new { mensagem = "Carrinho não encontrado." });

				_carrinhoRepositorio.Remover(carrinho);

				var commitResult = _unitOfWork.Commit();
				if (!commitResult.Success)
					return BadRequest(new { mensagem = "Erro ao remover o carrinho." });

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(new { mensagem = "Ocorreu um erro ao apagar o carrinho.", erro = ex.Message });
			}
		}

	}
}
