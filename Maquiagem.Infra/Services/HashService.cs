using Maquiagem.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Maquiagem.Infra.Services
{
	public class HashService : IHashService
	{

		private readonly IConfiguration _configuration;

		public HashService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string ComputeHash(string senha, string salt, int iteration)
		{
			if (iteration <= 0) return senha;
			using var sha256 = SHA256.Create();
			var passwordSalt = $"{senha}{salt}";
			var byteValue = Encoding.UTF8.GetBytes(passwordSalt);
			var byteHash = sha256.ComputeHash(byteValue);
			var hash = Convert.ToBase64String(byteHash);
			return ComputeHash(hash, salt, iteration - 1);
		}
		public string GenerateSalt()
		{
			using var rng = RandomNumberGenerator.Create();
			var byteSalt = new byte[16];
			rng.GetBytes(byteSalt);
			var salt = Convert.ToBase64String(byteSalt);
			return salt;
		}

		public bool VerifyHash(string senha, string salt, string storedHash, int iteration)
		{
			var computedHash = ComputeHash(senha, salt, iteration);
			return computedHash == storedHash;
		}
	}
}
