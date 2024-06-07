using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    
    public class CargoDto
	{
        [Key]
        public int CargoId { get; set; }

		[Required(ErrorMessage = "E necessário uma descrição")]
		[MinLength(3)]
		[MaxLength(200)]
        
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "E necessário um Tipo")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Tipo { get; set; }

        [JsonIgnore]
        public VagasDto? VagasDto { get; set; }

		[ForeignKey("vagasid")]
		public int VagasId { get; set; }
	}
}
