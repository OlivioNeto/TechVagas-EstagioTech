using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class MatriculaDto
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "E necessário uma Número de Matricula")]
        [MinLength(11)]
        [MaxLength(15)]
        public string NumeroMatricula { get; set; }
    }
}
