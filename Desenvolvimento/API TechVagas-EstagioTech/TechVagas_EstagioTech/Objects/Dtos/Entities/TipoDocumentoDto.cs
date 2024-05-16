using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class TipoDocumentoDto
    {
        [Key]
        public int idTipoDocumento { get; set; }

        [Required(ErrorMessage = "Informe a descrição de documento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoTipoDocumento { get; set; }

        [JsonIgnore]
        [Column("tipodocumento")]
        public ICollection<TipoDocumentoModel>? TipoDocumentos { get; set; }
    }
}
