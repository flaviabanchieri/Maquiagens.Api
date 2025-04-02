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
		IConfiguration _config;
		public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IConfiguration config)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_config=config;
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
				var claims = new[]
				{
					new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim("UserId", usuario.Id.ToString()),
					new Claim("Email", usuario.Email.ToString()),

				};

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
				var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
					claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signIn);
				string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

				return Ok(new {Token = tokenValue, Usuario = usuario});

			}
			return NoContent();
		}


	}
}
