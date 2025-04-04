using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Domain.Entidades;

namespace Maquiagem.Domain.Interfaces
{
	public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
	{
		Task<Usuario> ObterPorEmail(UsuarioDto dto);
		Task<bool> ValidarUsuarioExistente(UsuarioDto dto);
	}
}
