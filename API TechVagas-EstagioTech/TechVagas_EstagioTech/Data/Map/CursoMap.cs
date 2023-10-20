using TechVagas_EstagioTech.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Data.Map
{
    public class CursoMap : IEntityTypeConfiguration<CursoModel>
    {
        public void Configure(EntityTypeBuilder<CursoModel> builder)
        {
            builder.HasKey(x => x.idCurso);
            builder.Property(x => x.nomeCurso).IsRequired().HasMaxLength(200);
        }
    }
}
