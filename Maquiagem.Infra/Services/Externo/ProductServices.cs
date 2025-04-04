using Maquiagem.Application.DTOs.Produtos;
using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Interfaces;
using System.Text.Json;
using System.Web;

namespace Maquiagem.Infra.Services.Externo
{
	public class ProductServices : IProductService
	{
		private readonly HttpClient _httpClient;
		private readonly IProdutoRepositorio _productRepositorio;

		public ProductServices(HttpClient httpClient, IProdutoRepositorio productRepositorio)
		{
			_httpClient = httpClient;
			_productRepositorio = productRepositorio;
		}

		public async Task<List<ProductDto>> ObterProdutos(ProdutosFiltroDto filtro)
		{
			var queryString = ConstruirQueryString(filtro);
			var url = "http://makeup-api.herokuapp.com/api/v1/products.json" + queryString;
			List<ProductDto> products = new();
			try
			{
				var response = await _httpClient.GetAsync(url);

				response.EnsureSuccessStatusCode(); 

				var jsonString = await response.Content.ReadAsStringAsync();
				
				products = JsonSerializer.Deserialize<List<ProductDto>>(jsonString);

				if (products == null || products.Count == 0)
				{
					Console.WriteLine("Nenhum produto encontrado na API.");
				}

			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"Erro na desserialização JSON: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro inesperado: {ex.Message}");
			}
			return products;
		}

		private string ConstruirQueryString(ProdutosFiltroDto filtro)
		{
			var queryParams = HttpUtility.ParseQueryString(string.Empty);

			if (filtro.Id > 0) queryParams["id"] = filtro.Id.ToString();
			if (!string.IsNullOrEmpty(filtro.ProductType)) queryParams["product_type"] = filtro.ProductType;
			if (!string.IsNullOrEmpty(filtro.ProductCategory)) queryParams["product_category"] = filtro.ProductCategory;
			if (filtro.ProductTags != null && filtro.ProductTags.Any()) queryParams["product_tags"] = string.Join(",", filtro.ProductTags);
			if (!string.IsNullOrEmpty(filtro.Brand)) queryParams["brand"] = filtro.Brand;
			if (filtro.PriceGreaterThan.HasValue) queryParams["price_greater_than"] = filtro.PriceGreaterThan.Value.ToString();
			if (filtro.PriceLessThan.HasValue) queryParams["price_less_than"] = filtro.PriceLessThan.Value.ToString();

			var queryString = queryParams.ToString();
			return string.IsNullOrEmpty(queryString) ? string.Empty : "?" + queryString;
		}
	}
}
