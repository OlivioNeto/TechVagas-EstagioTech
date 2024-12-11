using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Objects.Interface;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("tipodocumento")]
    public class TipoDocumentoModel : IStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("tipodocumentoid")]
        public int idTipoDocumento { get; set; }

        [Column("descricao")]
        public string? descricaoTipoDocumento { get; set; }

        [Column("statustipodocumento")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        public virtual ICollection<DocumentoNecessarioModel>? DocumentosNecessarios { get; set; }

        public virtual ICollection<DocumentoModel>? Documento { get; set; }
    }
}