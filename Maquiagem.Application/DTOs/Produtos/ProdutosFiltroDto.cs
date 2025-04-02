using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Produtos
{
	public class ProdutosFiltroDto
	{
		public int Id { get; set; }
		public string? ProductType { get; set; }
		public string? ProductCategory { get; set; }
		public List<string>? ProductTags { get; set; }
		public string? Brand { get; set; }
		public decimal? PriceGreaterThan { get; set; }
		public decimal? PriceLessThan { get; set; }
		public double? RatingGreaterThan { get; set; }
		public double? RatingLessThan { get; set; }
	}
}
