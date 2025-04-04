using System.Text.Json.Serialization;

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
