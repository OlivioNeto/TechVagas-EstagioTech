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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
			services.AddDbContext<AppDbContext>(options =>
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


            services.AddAuthentication(options => // Configuração do serviço de autorização
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }) 
			.AddJwtBearer(options =>

            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "TechVagasEstagioTech",
                    ValidAudience = "WebSite",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E2F53C76E74237C824A47C7C4156510C818A7D4C98C8E9A3105C1C7D9240E5C3"))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });


            services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechVagas_EstagioTech", Version = "v1" });
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

            //Adiciona a autenticacão
            app.UseAuthentication();

            //habilita a autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
