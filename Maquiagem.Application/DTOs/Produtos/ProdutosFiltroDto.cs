namespace Maquiagem.Application.DTOs.Produtos
{
	public class ProdutosFiltroDto
	{
		public int Id { get; set; }
		public string? ProductType { get; set; }
		public string? ProductCategory { get; set; }
		public List<string>? ProductTags { get; set; }
		public string? Brand { get; set; }
		public int? PriceGreaterThan { get; set; }
		public int? PriceLessThan { get; set; }
	}
}
