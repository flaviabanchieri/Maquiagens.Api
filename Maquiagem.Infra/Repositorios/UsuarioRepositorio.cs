using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Infra.Repositorios
{
	public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public UsuarioRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Usuario> ObterPorEmaileSenha(UsuarioDto dto)
		{
			return await _context.Set<Usuario>().Where(
				user => user.Email == dto.Email && user.Senha == dto.Senha).FirstOrDefaultAsync();
		}

	}
}
