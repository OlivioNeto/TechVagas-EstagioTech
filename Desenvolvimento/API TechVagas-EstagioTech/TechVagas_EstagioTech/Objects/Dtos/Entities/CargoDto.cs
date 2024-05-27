using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
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

    }
}
