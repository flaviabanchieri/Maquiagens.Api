using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.Interfaces;
using Maquiagem.Application.Utils;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Maquiagem.Api.Controllers
{
	[ApiController]
	[Route("api/usuarios")]
	[Tags("Usuário")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		private readonly ITokenService _tokenService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHashService _hashService;
		private const int _iterationCount = 3;

		public UsuarioController(
			IUsuarioRepositorio usuarioRepositorio,
			IUnitOfWork unitOfWork,
			ITokenService tokenService,
			IHashService hashService)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_unitOfWork = unitOfWork;
			_tokenService = tokenService;
			_hashService = hashService;
		}

		[HttpPost("cadastro")]
		public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDto usuarioDto)
		{
			if (usuarioDto == null)
				return BadRequest(new { mensagem = "Dados inválidos." });

			if (await _usuarioRepositorio.ValidarUsuarioExistente(usuarioDto))
				return Conflict(new { mensagem = "Usuário já existe." });

			var senhaSalt = _hashService.GenerateSalt();
			var senhaCriptografada = _hashService.ComputeHash(usuarioDto.Senha, senhaSalt, _iterationCount);

			var novoUsuario = new Usuario
			{
				Nome = usuarioDto.Nome,
				Email = usuarioDto.Email,
				Senha = senhaCriptografada,
				SenhaSalt = senhaSalt
			};

			await _usuarioRepositorio.AdicionarAsync(novoUsuario);

			var commitResult = _unitOfWork.Commit();
			return commitResult.Success
				? CreatedAtAction(nameof(CadastrarUsuario), new { mensagem = commitResult.Message })
				: StatusCode(500, new { mensagem = commitResult.Message });
		}

		[HttpPost("login")]
		public async Task<IActionResult> AutenticarUsuario([FromBody] UsuarioDto usuarioDto)
		{

			if (usuarioDto == null)
				return BadRequest(new { mensagem = "Dados inválidos." });

			var usuario = await _usuarioRepositorio.ObterPorEmail(usuarioDto);
			if (usuario == null)
				return Unauthorized(new { mensagem = "E-mail ou senha incorretos." });

			var senhaCriptografada = _hashService.ComputeHash(usuarioDto.Senha, usuario.SenhaSalt, _iterationCount);
			if (usuario.Senha != senhaCriptografada)
				return Unauthorized(new { mensagem = "E-mail ou senha incorretos." });

			usuarioDto.Id = usuario.Id;
			var token = _tokenService.GenerateToken(usuarioDto);

			return Ok(new { Token = token, Usuario = usuario });
		}
	}
}
