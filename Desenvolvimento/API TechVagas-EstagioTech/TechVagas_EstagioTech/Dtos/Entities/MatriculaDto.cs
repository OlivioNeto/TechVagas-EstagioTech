using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class MatriculaDto
    {
        [Key]
        public int MatriculaId { get; set; }

        [Required(ErrorMessage = "E necessário uma Número de Matricula")]
        [MinLength(11)]
        [MaxLength(15)]
        public string NumeroMatricula { get; set; }
      
        [JsonIgnore]
        [Column("alunos")]
        public ICollection<AlunoModel>?Alunos{ get; set; }

        [JsonIgnore]
        [Column("cursos")]
        public ICollection<CursoModel>? Cursos { get; set; }
    }
}
