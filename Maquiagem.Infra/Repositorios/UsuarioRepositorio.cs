using Maquiagem.Application.DTOs.Auth;
using Maquiagem.Domain.Entidades;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Maquiagem.Infra.Repositorios
{
	public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
	{
		private readonly MaquiagemDbContext _context;

		public UsuarioRepositorio(MaquiagemDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Usuario> ObterPorEmail(UsuarioDto dto)
		{
			var usuario = await _context.Set<Usuario>().Where(
				user => user.Email == dto.Email).FirstOrDefaultAsync();
			return usuario;
		}
		public async Task<bool> ValidarUsuarioExistente(UsuarioDto dto)
		{
			var quantidadeDeRegistros = _context.Set<Usuario>().Where(
				user => user.Email == dto.Email).Count();

			return quantidadeDeRegistros > 0;
		}

	}
}
