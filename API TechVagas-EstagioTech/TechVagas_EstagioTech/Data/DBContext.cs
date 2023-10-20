using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Data.Map;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }
        public DbSet<TipoEstagioModel> TipoEstagio { get; set; }
        public DbSet<CursoModel> Curso { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumento { get; set; }

        public DbSet<DocumentoModel> Documento { get; set; }
		public DbSet<CargoModel> Cargos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoEsatgioMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
