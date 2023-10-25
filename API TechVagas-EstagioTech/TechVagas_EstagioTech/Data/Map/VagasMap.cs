using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Data.Map
{
    public class VagasMap : IEntityTypeConfiguration<VagasModel>
    {
        public void Configure(EntityTypeBuilder<VagasModel> builder)
        {
            builder.HasKey(x => x.VagasId);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.DataPublicacao).IsRequired();
            builder.Property(x => x.DataLimite).IsRequired();
            builder.Property(x => x.Localidade).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(80);
            builder.Property(x => x.LocalidadeTrabalho).IsRequired().HasMaxLength(20);
            builder.Property(x => x.HorarioEntrada).IsRequired().HasMaxLength(20);
            builder.Property(x => x.HorarioSaida).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TotalHorasSemanis).IsRequired().HasMaxLength(20);
        }
    }
}
