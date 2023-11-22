using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace TechVagas_EstagioTech
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<DBContext>(options =>
				options.UseNpgsql(connectionString));

			// Garantir que todos os assemblies do domínio sejam injetados
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Injeção de dependência
			services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
			services.AddScoped<IAlunoService, AlunoService>();

			services.AddScoped<IConcedenteRepositorio, ConcedenteRepositorio>();
			services.AddScoped<IConcedenteService, ConcedenteService>();

			services.AddScoped<ICargoRepositorio, CargoRepositorio>();
			services.AddScoped<ICargoService, CargoService>();

			services.AddScoped<ICursoRepositorio, CursoRepositorio>();
			services.AddScoped<ICursoService, CursoService>();

			services.AddScoped<IDocumentoRepositorio, DocumentoRepositorio>();
			services.AddScoped<IDocumentoService, DocumentoService>();

			services.AddScoped<IDocumentoVersaoRepositorio, DocumentoVersaoRepositorio>();
			services.AddScoped<IDocumentoVersaoService, DocumentoVersaoService>();

			services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
			services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

			services.AddScoped<ITipoEstagioRepositorio, TipoEstagioRepositorio>();
			services.AddScoped<ITipoEstagioService, TipoEstagioService>();

			services.AddScoped<IVagasRepositorio, VagasRepositorio>();
			services.AddScoped<IVagasService, VagasService>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000", "http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireClaim("scope", "sged");
                });
            });


            services.AddAuthorization(); // Configuração do serviço de autorização

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sua API", Version = "v1" });
			});

			services.AddMvc(); // Certifique-se de adicionar isto se ainda não estiver adicionado
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sua API V1"));
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseStaticFiles();

			app.UseCors("MyPolicy");

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
