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
		 private readonly IUsuarioRepositorio _usuarioRepositorio;
		 private readonly ITokenService _tokenService;
		 private readonly IUnitOfWork _unitOfWork;
		private readonly  IHashService _hashService;
		public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IUnitOfWork unitOfWork, ITokenService tokenService, IHashService hashService)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_unitOfWork = unitOfWork;
			_tokenService = tokenService;
			_hashService=hashService;
		}

		[HttpPost]
		[Route("Cadastro")]
		public async Task<IActionResult> Cadastro([FromBody] UsuarioDto dto) 
		{
			string senhaSalt = _hashService.GenerateSalt();
			string senhaCriptografada = _hashService.ComputeHash(dto.Senha, senhaSalt, 3);

			Usuario usuario = new() {
				Nome = dto.Nome, 
				Email = dto.Email,
				Senha = senhaCriptografada,
				SenhaSalt = senhaSalt
			};

			await _usuarioRepositorio.AdicionarAsync(usuario);
			
			try
			{
				var sucesso = _unitOfWork.Commit();
				return Ok(new { mensagem = "Cadastro realizado com sucesso!" });
			}
			catch (Exception ex)
			{
				return BadRequest(new {mensagem = ex.Message});
				throw;
			}				
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
