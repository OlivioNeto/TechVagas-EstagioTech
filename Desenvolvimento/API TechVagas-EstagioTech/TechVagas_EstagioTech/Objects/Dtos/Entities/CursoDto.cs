using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class CursoDto
    {
        [Key]
        public int cursoid { get; set; }

        [Required(ErrorMessage = "E necessário o nome do curso")]
        [MinLength(3)]
        [MaxLength(150)]
        public string nomeCurso { get; set; }

        [Required(ErrorMessage = "E necessário o turno do curso")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? turnoCurso { get; set; }

        public string? StatusCoordenadorEstagio { get; set; }

        [JsonIgnore]
        [Column("cursoid")]
        public ICollection<CursoModel>? Curso { get; set; }

    }
}
