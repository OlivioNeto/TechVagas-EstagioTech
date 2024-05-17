using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class ConcedenteDto
    {
        [Key]
        public int concedenteId { get; set; }

        [Required(ErrorMessage = "E necessário uma Razão Social")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? RazaoSocial { get; set; }


        [Required(ErrorMessage = "E necessário um Responsável de Estágio")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? ResponsavelEstagio { get; set; }


        [Required(ErrorMessage = "E necessário um Cnpj")]
        [MinLength(14)]
        [MaxLength(16)]
        public string? Cnpj { get; set; }


        [Required(ErrorMessage = "E necessário uma Localidade")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Localidade { get; set; }

        [JsonIgnore]

        [Column("vagas")]
        public ICollection<VagasModel>? Vagas { get; set; }
    }
}
