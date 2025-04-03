using System;
using System.Collections.Generic;

namespace Maquiagem.Domain.Entidades
{
	public class Produto : EntityBase<Produto>
	{
		public int? Id { get; private set; }
		public string Brand { get; private set; }
		public string Name { get; private set; }
		public string Price { get; private set; }
		public string PriceSign { get; private set; }
		public string Currency { get; private set; }
		public string ImageLink { get; private set; }
		public string ProductLink { get; private set; }
		public string WebsiteLink { get; private set; }
		public string Description { get; private set; }
		public double? Rating { get; private set; }
		public string Category { get; private set; }
		public string ProductType { get; private set; }
		public List<string> TagList { get; private set; }
		public DateTime? CreatedAt { get; private set; }
		public DateTime? UpdatedAt { get; private set; }
		public string ProductApiUrl { get; private set; }
		public string ApiFeaturedImage { get; private set; }
		public int? ProdutoId { get; private set; }
		public List<CorProduto> ProductColors { get; private set; }
		private Produto() { }
		public Produto(string brand, string name, string price, string priceSign, string currency,
					   string imageLink, string productLink, string websiteLink, string description,
					   string category, string productType, List<string> tagList, DateTime? createdAt,
					   DateTime? updatedAt, string productApiUrl, string apiFeaturedImage, int produtoId)
		{
			Brand = brand;
			Name = name;
			Price = price;
			PriceSign = priceSign;
			Currency = currency;
			ImageLink = imageLink;
			ProductLink = productLink;
			WebsiteLink = websiteLink;
			Description = description;
			Category = category;
			ProductType = productType;
			TagList = tagList ?? new List<string>(); 
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
			ProductApiUrl = productApiUrl;
			ApiFeaturedImage = apiFeaturedImage;
			ProdutoId = produtoId;
		}
	}
}
