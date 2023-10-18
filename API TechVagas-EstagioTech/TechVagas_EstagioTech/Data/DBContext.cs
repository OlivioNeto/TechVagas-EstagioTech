using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Data.Map;
using TechVagas_EstagioTech.Model;
using Microsoft.EntityFrameworkCore; 

namespace TechVagas_EstagioTech.Data
{
    public class DBContex : DbContext
    {
        public DBContex(DbContextOptions<DBContex> options)
            : base(options)
        {

        }
        public DbSet<TipoEstagioModel> TipoEstagio { get; set; }
        public DbSet<CursoModel> Curso { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumento { get; set; }

        public DbSet<DocumentoModel> Documento { get; set; }

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
