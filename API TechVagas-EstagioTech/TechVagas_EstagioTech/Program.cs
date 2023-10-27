using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Repositorios;

namespace TechVagas_EstagioTech
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DBContext>(options =>
                          options.UseNpgsql(connectionString));


			//garantir que todos os assemblies do domain sejam injetados
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


			//Injeção de dependencia
			builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
			builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
			builder.Services.AddScoped<IDocumentoRepositorio, DocumentoRepositorio>();
			builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
			builder.Services.AddScoped<ITipoEstagioRepositorio, TipoEstagioRepositorio>();
			builder.Services.AddScoped<IVagasRepositorio, VagasRepositorio>();



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

