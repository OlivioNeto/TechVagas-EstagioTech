using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class InstituicaoEnsinoDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "E necessário o nome da Institução")]
        [MinLength(3)]
        [MaxLength(200)]
        public string NomeInstituicao { get; set; }

        [Required(ErrorMessage = "E necessário um local")]
        [MinLength(3)]
        [MaxLength(120)]
        public string Local { get; set; }

        [Required(ErrorMessage = "E necessário um telefone")]
        [MinLength(15)]
        [MaxLength(17)]
        public string Telefone { get; set; }
    }
}
