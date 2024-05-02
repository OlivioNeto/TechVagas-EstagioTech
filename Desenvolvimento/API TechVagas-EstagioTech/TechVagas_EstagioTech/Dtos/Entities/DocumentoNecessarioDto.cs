using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class DocumentoNecessarioDto
    {
        [Key]
        public int idDocumentoNecessario { get; set; }

        //[JsonIgnore]
        public TipoDocumentoDto? TipoDocumento { get; set; }

        //[JsonIgnore]
        public TipoEstagioDto? TipoEstagio { get; set; }
        public int idTipoDocumento { get; set; }
        public int idTipoEstagio { get; set; }
    }
}
