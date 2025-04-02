using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Produtos
{
	public class ProductDto
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("brand")]
		public string Brand { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("price")]
		public string Price { get; set; }

		[JsonPropertyName("price_sign")]
		public string PriceSign { get; set; }

		[JsonPropertyName("currency")]
		public string Currency { get; set; }

		[JsonPropertyName("image_link")]
		public string ImageLink { get; set; }

		[JsonPropertyName("product_link")]
		public string ProductLink { get; set; }

		[JsonPropertyName("website_link")]
		public string WebsiteLink { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("rating")]
		public object Rating { get; set; }

		[JsonPropertyName("category")]
		public string Category { get; set; }

		[JsonPropertyName("product_type")]
		public string ProductType { get; set; }

		[JsonPropertyName("tag_list")]
		public List<string> TagList { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonPropertyName("product_api_url")]
		public string ProductApiUrl { get; set; }

		[JsonPropertyName("api_featured_image")]
		public string ApiFeaturedImage { get; set; }

		[JsonPropertyName("product_colors")]
		public List<ProductColorDto> ProductColors { get; set; }
	}
}
