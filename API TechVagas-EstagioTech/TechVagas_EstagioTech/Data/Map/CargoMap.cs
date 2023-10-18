using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Model;

namespace TechVagas_EstagioTech.Data.Map
{
	public class CargoMap : IEntityTypeConfiguration<CargoModel>
	{
		public void Configure(EntityTypeBuilder<CargoModel> builder)
		{
			builder.HasKey(x => x.CargoId);
			builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
			builder.Property(x => x.Tipo).IsRequired().HasMaxLength(50);
		}
	}
}
