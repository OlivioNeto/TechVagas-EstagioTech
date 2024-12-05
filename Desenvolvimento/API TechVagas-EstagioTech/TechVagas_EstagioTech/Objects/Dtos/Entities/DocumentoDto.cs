using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Interface;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class DocumentoDto : IStatus
    {
        [Key]
        public int idDocumento { get; set; }

        [Required(ErrorMessage = "Informe a descrição do documento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoDocumento { get; set; }

        [Required(ErrorMessage = "Informe a situação do documento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? situacaoDocumento { get; set; }

        [Required(ErrorMessage = "O status é requerido!")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        [JsonIgnore]
        public CoordenadorEstagioDto? CoordenadorEstagio { get; set; }
        public int idCoordenadorEstagio { get; set; }

        [JsonIgnore]
        public TipoDocumentoDto? TipoDocumento { get; set; }
        public int idTipoDocumento { get; set; }

        [JsonIgnore]
        [Column("documento")]
        public ICollection<DocumentoModel>? Documento { get; set; }

        [JsonIgnore]
        public ContratoEstagioDto? ContratoEstagio { get; set; }
        public int idContratoEstagio { get; set; }
    }
}
