﻿using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Maquiagem.Infra.Services
{
	public class TokenService : ITokenService
	{

		private readonly IConfiguration _config;

		public TokenService(IConfiguration config)
		{
			_config = config;
		}

		public string GenerateToken(UsuarioDto user)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim("UserId", user.Id.ToString()),
				new Claim("Email", user.Email.ToString()),

			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				_config["Jwt:Issuer"],
				_config["Jwt:Audience"],
				claims, expires: DateTime.UtcNow.AddMinutes(60),
				signingCredentials: signIn
				);
			string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
			return tokenValue;
		}

	}
}
