using Maquiagem.Application.DTOs.Auth;

namespace Maquiagem.Application.Interfaces
{
	public interface ITokenService
	{
		string GenerateToken(UsuarioDto user);
	}
}
