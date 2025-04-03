using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.Interfaces
{
	public interface IHashService
	{
		string ComputeHash(string senha, string salt, int iteration);
		string GenerateSalt();
		bool VerifyHash(string senha, string salt, string storedHash, int iteration);
	}
}
