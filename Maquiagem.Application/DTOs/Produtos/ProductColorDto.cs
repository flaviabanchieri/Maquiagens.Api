using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Maquiagem.Application.DTOs.Produtos
{
	public class ProductColorDto
	{
		[JsonPropertyName("hex_value")]
		public string HexValue { get; set; }

		[JsonPropertyName("colour_name")]
		public string ColourName { get; set; }
	}
}
