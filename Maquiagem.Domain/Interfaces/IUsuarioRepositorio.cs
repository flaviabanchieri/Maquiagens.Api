using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Domain.Interfaces
{
	public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
	{
		Task<Usuario> ObterPorEmail(UsuarioDto dto);
		Task<bool> ValidarUsuarioExistente(UsuarioDto dto);
	}
}
