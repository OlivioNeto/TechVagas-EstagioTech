using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class TipoEstagioDto
    {
        [Key]
        public int idTipoEstagio { get; set; }

        [Required(ErrorMessage = "Informe a descrição do tipo do estágio")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoTipoEstagio { get; set; }

        [JsonIgnore]
        [Column("tipoestagioid")]
        public ICollection<TipoEstagioModel>? TipoEstagios { get; set; }
    }
}
