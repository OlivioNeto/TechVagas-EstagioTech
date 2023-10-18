using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;

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

            builder.Services.AddTransient<ITipoEstagioRepositorio, TipoEstagioRepositorio>();
            builder.Services.AddTransient<ICursoRepositorio, CursoRepositorio>();
            builder.Services.AddTransient<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
            builder.Services.AddTransient<IDocumentoRepositorio, DocumentoRepositorio>();
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

