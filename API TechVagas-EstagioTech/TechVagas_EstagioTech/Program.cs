using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Repositorios.Entities;

namespace TechVagas_EstagioTech
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbucklee 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DBContext>(options =>
                          options.UseNpgsql(connectionString));


			//garantir que todos os assemblies do domain sejam injetados
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Injeção de dependencia

            //aluno
            builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            builder.Services.AddScoped<IAlunoService, AlunoService>();

            //cargo
            builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            builder.Services.AddScoped<ICargoService, CargoService>();

            //curso
            builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
			builder.Services.AddScoped<ICursoService, CursoService>();

            //documento
			builder.Services.AddScoped<IDocumentoRepositorio, DocumentoRepositorio>();
			builder.Services.AddScoped<IDocumentoService, DocumentoService>();

            //documemento versão
            builder.Services.AddScoped<IDocumentoVersaoRepositorio, DocumentoVersaoRepositorio>();
            builder.Services.AddScoped<IDocumentoVersaoService, DocumentoVersaoService>();

            //tipo documento
            builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
			builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

            //tipo estagio
			builder.Services.AddScoped<ITipoEstagioRepositorio, TipoEstagioRepositorio>();
			builder.Services.AddScoped<ITipoEstagioService, TipoEstagioService>();

            //vagas
            builder.Services.AddScoped<IVagasRepositorio, VagasRepositorio>();
			builder.Services.AddScoped<IVagasService, VagasService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

