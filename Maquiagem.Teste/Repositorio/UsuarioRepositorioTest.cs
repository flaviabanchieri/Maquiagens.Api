
using Maquiagem.Domain.Entidades;
using Maquiagem.Infra.Data;
using Maquiagem.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace Maquiagem.Teste.Repositorio
{
	[TestFixture]
	public class UsuarioRepositorioTests
	{
		private MaquiagemDbContext _context;
		private UsuarioRepositorio _repositorio;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<MaquiagemDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
				.Options;

			_context = new MaquiagemDbContext(options);
			_repositorio = new UsuarioRepositorio(_context);
		}

		[TearDown]
		public void TearDown()
		{
			_repositorio?.Dispose(); 
			_context?.Dispose();
		}

		[Test]
		public async Task ObterPorEmail_DeveRetornarUsuario_QuandoEmailExiste()
		{
			// Arrange
			var usuario = new Usuario { Nome = "Flavia", Email = "teste@email.com", Senha = "123", SenhaSalt = "456"};
			_context.Set<Usuario>().Add(usuario);
			await _context.SaveChangesAsync();

			// Act
			var resultado = await _repositorio.ObterPorEmail(new Application.DTOs.Auth.UsuarioDto { Email = "teste@email.com" });

			// Assert
			Assert.That(resultado != null);
			Assert.That("Flavia" == resultado.Nome);
		}
	}
}