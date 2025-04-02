using Maquiagem.Application.DTOs.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.Interfaces
{
	public interface ITokenService
	{
		string GenerateToken(UsuarioDto user);
	}
}
