using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Interface;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class TipoDocumentoDto : IStatus
    {
        [Key]
        public int idTipoDocumento { get; set; }

        [Required(ErrorMessage = "Informe a descrição de documento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoTipoDocumento { get; set; }


        [Required(ErrorMessage = "O status é requerido!")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);


        [JsonIgnore]
        [Column("tipodocumento")]
        public ICollection<TipoDocumentoModel>? TipoDocumentos { get; set; }
    }
}
