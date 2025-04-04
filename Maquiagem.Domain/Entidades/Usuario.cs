namespace Maquiagem.Domain.Entidades
{
	public class Usuario : EntityBase<Usuario>
	{
		public required string Nome { get; set; }
		public required string Email { get; set; }
		public required string Senha { get; set; }
		public required string SenhaSalt { get; set; }
		
	}
}
