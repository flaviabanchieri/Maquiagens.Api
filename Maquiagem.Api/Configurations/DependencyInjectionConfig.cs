using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Context;
using Maquiagem.Infra.Repositorios;
using Maquiagem.Infra.Services;
using Maquiagem.Infra.Services.Externo;

namespace Maquiagem.Api.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
			services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddHttpClient<IProductService, ProductServices>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IHashService, HashService>();
			services.AddHttpContextAccessor();
			services.AddScoped<IUsuarioContextService, UsuarioContextService>();
			services.AddScoped<ICarrinhoRepositorio, CarrinhoRepositorio>();
			services.AddScoped<ICompraRepositorio, CompraRepositorio>();
		}
	}
}
