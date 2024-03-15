using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class CoordenadorEstagioDto
    {
        [Key]
        public int idCoordenadorEstagio { get; set; }

        [Required(ErrorMessage = "Informe a data de cadastro do Coordenador")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? dataCadastro { get; set; }

        public string? StatusCoordenadorEstagio { get; set; }

        [JsonIgnore]
        [Column("coordenadorestagio")]
        public ICollection<CoordenadorEstagioModel>? CoordenadorEstagio { get; set; }
    }
}
