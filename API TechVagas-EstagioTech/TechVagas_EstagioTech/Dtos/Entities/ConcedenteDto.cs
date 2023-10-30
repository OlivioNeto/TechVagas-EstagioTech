using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class ConcedenteDto
    {

        public int concedenteId { get; set; }

        [Required(ErrorMessage = "E necessário uma Razão Social")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? RazaoSocial { get; set; }


        [Required(ErrorMessage = "E necessário um Responsável de Estágio")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? ResponsavelEstagio { get; set; }


        [Required(ErrorMessage = "E necessário um Cnpj")]
        [MinLength(14)]
        [MaxLength(16)]
        public string? Cnpj { get; set; }


        [Required(ErrorMessage = "E necessário uma Localidade")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Localidade { get; set; }
    }
}
