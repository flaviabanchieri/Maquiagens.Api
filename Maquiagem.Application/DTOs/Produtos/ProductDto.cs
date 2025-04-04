using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Maquiagem.Application.DTOs.Produtos
{
	public class ProductDto
	{
		[JsonPropertyName("id")]
		public int Id { get; set; } = 0;

		[JsonPropertyName("brand")]
		public string Brand { get; set; } = string.Empty;

		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;

		[JsonPropertyName("price")]
		public string Price { get; set; } = "0.00";

		[JsonPropertyName("price_sign")]
		public string PriceSign { get; set; } = string.Empty;

		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;

		[JsonPropertyName("image_link")]
		public string ImageLink { get; set; } = string.Empty;

		[JsonPropertyName("product_link")]
		public string ProductLink { get; set; } = string.Empty;

		[JsonPropertyName("website_link")]
		public string WebsiteLink { get; set; } = string.Empty;

		[JsonPropertyName("description")]
		public string Description { get; set; } = string.Empty;

		[JsonPropertyName("rating")]
		public double? Rating { get; set; } = null;

		[JsonPropertyName("category")]
		public string Category { get; set; } = string.Empty;

		[JsonPropertyName("product_type")]
		public string ProductType { get; set; } = string.Empty;

		[JsonPropertyName("tag_list")]
		public List<string> TagList { get; set; } = new();

		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; } = DateTime.MinValue;

		[JsonPropertyName("product_api_url")]
		public string ProductApiUrl { get; set; } = string.Empty;

		[JsonPropertyName("api_featured_image")]
		public string ApiFeaturedImage { get; set; } = string.Empty;

		[JsonPropertyName("product_colors")]
		public List<ProductColorDto> ProductColors { get; set; } = new();
	}
}
