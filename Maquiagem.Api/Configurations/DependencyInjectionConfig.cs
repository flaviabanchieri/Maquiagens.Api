using Maquiagem.Application.Interfaces;
using Maquiagem.Domain.Interfaces;
using Maquiagem.Infra.Repositorios;
using Maquiagem.Infra.Services.Externo;

namespace Maquiagem.Api.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IProductRepositorio, ProductRepositorio>();
			services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
			services.AddHttpClient<IProductService, ProductServices>();
			services.AddHttpClient<ITokenService, ITokenService>();
		}
	}
}
