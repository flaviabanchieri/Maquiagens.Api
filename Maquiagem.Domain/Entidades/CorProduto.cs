namespace Maquiagem.Domain.Entidades
{
	public class CorProduto
	{
		public string HexValue { get; set; }
		public string ColourName { get; set; }
		public List<Produto> Products { get; set; } = new List<Produto>();
	}
}
