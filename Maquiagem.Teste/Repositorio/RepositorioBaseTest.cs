using Maquiagem.Domain.Entidades;
using Maquiagem.Infra.Data;
using Maquiagem.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Maquiagem.Teste.Repositorio
{
	[TestFixture]
	public class RepositorioBaseTests
	{
		private MaquiagemDbContext _context;
		private RepositorioBase<Usuario> _repositorio;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<MaquiagemDbContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new MaquiagemDbContext(options);
			_repositorio = new RepositorioBase<Usuario>(_context);
		}

		[TearDown]
		public void TearDown()
		{
			_repositorio?.Dispose();
			_context?.Dispose();
		}

		[Test]
		public async Task AdicionarAsync_DeveAdicionarUsuario()
		{
			// Arrange
			var usuario = new Usuario { Nome = "Teste", Email = "teste@email.com", Senha = "123", SenhaSalt = "abc" };

			// Act
			await _repositorio.AdicionarAsync(usuario);
			_context.SaveChanges();

			// Assert
			var usuarios = await _context.Set<Usuario>().ToListAsync();
			Assert.That(usuarios.Count, Is.EqualTo(1));
			Assert.That(usuarios.First().Nome, Is.EqualTo("Teste"));
		}

		[Test]
		public async Task Atualizar_DeveAtualizarUsuario()
		{
			// Arrange
			var usuario = new Usuario { Nome = "Antes", Email = "teste@atualizar.com", Senha = "123", SenhaSalt = "salt" };
			await _repositorio.AdicionarAsync(usuario);
			_context.SaveChanges();

			// Act
			usuario.Nome = "Depois";
			_repositorio.Atualizar(usuario);
			_context.SaveChanges();

			var atualizado = await _repositorio.ObterPorIdAsync(usuario.Id);

			// Assert
			Assert.That(atualizado.Nome, Is.EqualTo("Depois"));
		}

		[Test]
		public async Task Remover_DeveRemoverUsuario()
		{
			// Arrange
			var usuario = new Usuario { Nome = "Para Remover", Email = "remover@email.com", Senha = "123", SenhaSalt = "salt" };
			await _repositorio.AdicionarAsync(usuario);
			_context.SaveChanges();

			// Act
			_repositorio.Remover(usuario);
			_context.SaveChanges();

			var resultado = await _repositorio.ObterPorIdAsync(usuario.Id);

			// Assert
			Assert.That(resultado, Is.Null);
		}

		[Test]
		public async Task BuscarAsync_DeveRetornarUsuariosComNomeContendoFiltro()
		{
			// Arrange
			await _repositorio.AdicionarMultiplosAsync(new List<Usuario>
	{
		new Usuario { Nome = "Ana", Email = "ana@email.com", Senha = "123", SenhaSalt = "1" },
		new Usuario { Nome = "Bruna", Email = "bruna@email.com", Senha = "456", SenhaSalt = "2" },
		new Usuario { Nome = "Carlos", Email = "carlos@email.com", Senha = "789", SenhaSalt = "3" }
	});
			_context.SaveChanges();

			// Act
			var resultado = await _repositorio.BuscarAsync(u => u.Nome.Contains("a"));

			// Assert
			Assert.That(resultado.Count(), Is.GreaterThanOrEqualTo(2));
		}


		[Test]
		public async Task ObterPorIdAsync_DeveRetornarUsuarioPeloId()
		{
			// Arrange
			var usuario = new Usuario { Nome = "Teste ID", Email = "id@email.com", Senha = "id", SenhaSalt = "salt" };
			await _repositorio.AdicionarAsync(usuario);
			_context.SaveChanges();

			var usuarioId = usuario.Id;

			// Act
			var resultado = await _repositorio.ObterPorIdAsync(usuarioId);

			// Assert
			Assert.That(resultado, Is.Not.Null);
			Assert.That(resultado.Nome, Is.EqualTo("Teste ID"));
		}
	}
}
