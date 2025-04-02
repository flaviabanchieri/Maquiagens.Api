using AutoMapper;
using IntegradorAnuncios.Api.Mapper;
using Maquiagem.Api.Configurations;
using Maquiagem.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Maquiagem API",
		Version = "v1",
		Description = "API para o sistema de loja de maquiagem",
		Contact = new OpenApiContact
		{
			Name = "Flavia Banchieri",
			Email = "flavia.banchieri@infortechms.com.br"
		}
	});

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization no header utilizando o esquema Bearer. Exemplo: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header,
			},
			new List<string>()
		}
	});
});
var mappingConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.RegisterServices();

var connectionString = string.Empty;

builder.Services.AddDbContext<MaquiagemDbContext>((serviceProvider, dbContextBuilder) =>
{
	connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	dbContextBuilder.UseSqlServer(connectionString);

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Maquiagem API V1");
	c.RoutePrefix = string.Empty;
	c.DocumentTitle = "Maquiagem API Documentation";
	c.DisplayRequestDuration(); 
	c.EnableDeepLinking(); 
});

app.MapControllers();

app.Run();
