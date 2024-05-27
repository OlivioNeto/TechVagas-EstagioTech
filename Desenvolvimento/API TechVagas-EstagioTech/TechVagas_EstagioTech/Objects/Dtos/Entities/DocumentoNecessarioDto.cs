using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Interface;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class DocumentoNecessarioDto : IStatus
    {
        [Key]
        public int idDocumentoNecessario { get; set; }

        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        [JsonIgnore]
        public TipoDocumentoDto? TipoDocumento { get; set; }

        [JsonIgnore]
        public TipoEstagioDto? TipoEstagio { get; set; }
        public int idTipoDocumento { get; set; }
        public int idTipoEstagio { get; set; }
    }
}
