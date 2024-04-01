using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class ApontamentoDto
    {
        [Key]
        public int idApontamento { get; set; }

        [Required(ErrorMessage = "Informe a descrição do apontamento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoApontamento { get; set; }

        [Required(ErrorMessage = "Informe a data do apontamento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? dataApontamento { get; set; }

        [JsonIgnore]
        public ICollection<CoordenadorEstagioModel>? CoordenadorEstagio { get; set; }
        public int idCoordenadorEstagio { get; set; }
    }
}
