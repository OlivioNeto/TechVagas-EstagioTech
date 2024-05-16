using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
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
        public DateOnly? dataApontamento { get; set; }

        [JsonIgnore]
        public CoordenadorEstagioModel? CoordenadorEstagio { get; set; }
        public int idCoordenadorEstagio { get; set; }
    }
}
