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
using TechVagas_EstagioTech.Dtos.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechVagas_EstagioTech.Objects.Utilities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Services.Middleware;

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
            // Pega a variável de ambiente DB_HOST
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";

            // Pega a string de conexão do appsettings e substitui o host
            var connectionString = Configuration.GetConnectionString("DefaultConnection")
                .Replace("{DB_HOST}", dbHost);

            // Adiciona o DbContext ao container de injeção de dependência
            services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechVagas_EstagioTech", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Enter 'Bearer' [space] your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            In = ParameterLocation.Header
                        },
                        new List<string>()
            }
            });
            });

            // Configuração da autenticação JWT
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    SecurityEntity entitySecurity = new();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = entitySecurity.Issuer,
                        ValidAudience = entitySecurity.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(entitySecurity.Key)),
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministradorPolicy", policy => policy.RequireRole("Administrador"));
                options.AddPolicy("AlunoPolicy", policy => policy.RequireRole("Aluno"));
                options.AddPolicy("EmpresaPolicy", policy => policy.RequireRole("Empresa"));
            });

            // Garantir que todos os assemblies do domínio sejam injetados
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Injeção de dependência
			services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
			services.AddScoped<IAlunoService, AlunoService>();

			services.AddScoped<IApontamentoRepositorio, ApontamentoRepositorio>();
			services.AddScoped<IApontamentoService, ApontamentoService>();

			services.AddScoped<IConcedenteRepositorio, ConcedenteRepositorio>();
			services.AddScoped<IConcedenteService, ConcedenteService>();

			services.AddScoped<ICargoRepositorio, CargoRepositorio>();
			services.AddScoped<ICargoService, CargoService>();

			services.AddScoped<IContratoEstagioRepositorio, ContratoEstagioRepositorio>();
			services.AddScoped<IContratoEstagioService,ContratoEstagioService>();

			services.AddScoped<ICoordenadorEstagioRepositorio, CoordenadorEstagioRepositorio>();
			services.AddScoped<ICoordenadorEstagioService, CoordenadorEstagioService>();

			services.AddScoped<ICursoRepositorio, CursoRepositorio>();
			services.AddScoped<ICursoService, CursoService>();

			services.AddScoped<IDocumentoNecessarioRepositorio, DocumentoNecessarioRepositorio>();
			services.AddScoped<IDocumentoNecessarioService, DocumentoNecessarioService>();

			services.AddScoped<IDocumentoRepositorio, DocumentoRepositorio>();
			services.AddScoped<IDocumentoService, DocumentoService>();

			services.AddScoped<IDocumentoVersaoRepositorio, DocumentoVersaoRepositorio>();
			services.AddScoped<IDocumentoVersaoService, DocumentoVersaoService>();

			services.AddScoped<ISupervisorEstagioRepositorio, SupervisorEstagioRepositorio>();
			services.AddScoped<ISupervisorEstagioService , SupervisorEstagioService>();

			services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
			services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

			services.AddScoped<ITipoEstagioRepositorio, TipoEstagioRepositorio>();
			services.AddScoped<ITipoEstagioService, TipoEstagioService>();

			services.AddScoped<IVagasRepositorio, VagasRepositorio>();
			services.AddScoped<IVagasService, VagasService>();

			services.AddScoped<IInstituicaoEnsinoRepositorio, InstituicaoEnsinoRepositorio>();
            services.AddScoped<IInstituicaoEnsinoService, InstituicaoEnsinoService>();

            services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();
            services.AddScoped<IMatriculaService, MatriculaService>();

            services.AddScoped<ISessaoRepositorio, SessaoRepositorio>();
            services.AddScoped<ISessaoService, SessaoService>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioService, UsuarioService>();

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

			/*services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tech Vagas - Estagio Tech", Version = "v1" });
			});*/
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            app.UseCors("AllowSpecificOrigins");


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            /*app.UseWhen(context => context.Request.Path.StartsWithSegments("/api") && context.GetEndpoint()?.Metadata.GetMetadata<AnonymousAttribute>() == null,
            appBuilder =>
            {
                appBuilder.UseCustomMiddleware();
            });

            app.Use(async (context, next) =>
            {
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized) return;

                await next(context);
            });

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api") && context.GetEndpoint()?.Metadata.GetMetadata<AnonymousAttribute>() == null,
            appBuilder =>
            {
                appBuilder.UsePolicyMiddleware();
            });
            
            app.Use(async (context, next) =>
            {
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized) return;

                await next(context);
            });
             */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
