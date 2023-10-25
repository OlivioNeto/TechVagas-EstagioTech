using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    [Table("cargo")]
    public class CargoDto
	{
        [Key]
        [Column("cargoid")]
        public int CargoId { get; set; }

		[Required(ErrorMessage = "E necessário uma descrição")]
		[MinLength(3)]
		[MaxLength(80)]
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("tipo")]
        public string? Tipo { get; set; }

        [JsonIgnore]
        public VagasDto? VagasDto { get; set; }
	}
}
