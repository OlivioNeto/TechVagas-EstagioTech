using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechVagas_EstagioTech.Model;

namespace TechVagas_EstagioTech.Data.Map
{
    public class TipoEsatgioMap : IEntityTypeConfiguration<TipoEstagioModel>
    {
        public void Configure(EntityTypeBuilder<TipoEstagioModel> builder)
        {
            builder.HasKey(x => x.idTipoEstagio);
            builder.Property(x => x.descricaoTipoEstagio).IsRequired().HasMaxLength(200);
        }
    }
}
