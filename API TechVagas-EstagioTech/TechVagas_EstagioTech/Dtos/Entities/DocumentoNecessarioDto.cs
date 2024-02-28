using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class DocumentoNecessarioDto
    {
        [Key]
        public int DocumentoNecessarioId { get; set; }

        [JsonIgnore]
        public ICollection<TipoDocumentoModel>? TipoDocumentos { get; set; }

        [JsonIgnore]
        public ICollection<TipoEstagioModel>? TipoEstagios { get; set; }
        public int idTipoDocumento { get; set; }
        public int idTipoEstagio { get; set; }
    }
}
