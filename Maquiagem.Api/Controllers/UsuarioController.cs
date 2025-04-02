using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/usuario")]
	[Tags("Usuario")]
	public class UsuarioController : Controller
	{
		IUsuarioRepositorio _usuarioRepositorio;
		ITokenService _tokenService;
		IConfiguration _config;
		public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IConfiguration config, ITokenService tokenService)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_config=config;
			_tokenService = tokenService;
		}

		[HttpPost]
		[Route("Cadastro")]
		public IActionResult Cadastro([FromBody] UsuarioDto usuario) { 
			return View(usuario);
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] UsuarioDto dto)
		{
			Usuario usuario = await _usuarioRepositorio.ObterPorEmaileSenha(dto);
			if (usuario != null)
			{
				dto.Id = usuario.Id;
				var tokenValue = _tokenService.GenerateToken(dto);
				return Ok(new {Token = tokenValue, Usuario = usuario});

			}
			return NoContent();
		}


	}
}
