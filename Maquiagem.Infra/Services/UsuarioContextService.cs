using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.Interfaces;

namespace Maquiagem.Infra.Services
{
	public class UsuarioContextService : IUsuarioContextService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UsuarioContextService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public int PegarUsuarioIdLogado()
		{
			var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;

			if (identity != null)
			{
				var claims = identity.Claims;
				if (claims != null && claims.Any())
				{
					var usuarioClaim = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

					if (!string.IsNullOrEmpty(usuarioClaim) && int.TryParse(usuarioClaim, out int usuarioId))
					{
						return usuarioId;
					}
				}
			}
			return 0; 
		}
	}
}
