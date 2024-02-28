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
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
		   Host.CreateDefaultBuilder(args)
			   .ConfigureWebHostDefaults(webBuilder =>
			   {
				   webBuilder.UseStartup<Startup>();
			   });
	}
}

