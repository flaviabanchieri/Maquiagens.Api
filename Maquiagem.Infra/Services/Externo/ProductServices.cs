using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Services.Externo
{
	public class ProductServices : IProductService
	{
		private readonly HttpClient _httpClient;
		private readonly IProductRepositorio _productRepositorio;

		public ProductServices(HttpClient httpClient, IProductRepositorio productRepositorio)
		{
			_httpClient = httpClient;
			_productRepositorio = productRepositorio;
			_httpClient.BaseAddress = new Uri("http://makeup-api.herokuapp.com/api/v1/products.json");
		}

		public async Task<List<ProductDto>> ObterProdutos(ProdutosFiltroDto filtro)
		{
			try
			{
				var response = await _httpClient.GetAsync("http://makeup-api.herokuapp.com/api/v1/products.json");

				response.EnsureSuccessStatusCode(); 

				var jsonString = await response.Content.ReadAsStringAsync();

				var products = JsonSerializer.Deserialize<List<ProductDto>>(jsonString);

				if (products == null || products.Count == 0)
				{
					Console.WriteLine("Nenhum produto encontrado na API.");
					return null;
				}

				return products;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
				return null;
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"Erro na desserialização JSON: {ex.Message}");
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro inesperado: {ex.Message}");
				return null;
			}
		}
	}
}
