using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Objects.Interface;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("documento")]
    public class DocumentoModel : IStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("documentoid")]
        public int idDocumento { get; set; }

        [Column("descricao")]
        public string? descricaoDocumento { get; set; }

        [Column("statusdocumento")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        public TipoDocumentoModel? TipoDocumento { get; set; }
        [Column("tipodocumentoid")]
        public int idTipoDocumento { get; set; }

        public CoordenadorEstagioModel? CoordenadorEstagio { get; set; }
        [Column("coordenadorestagioid")]
        public int idCoordenadorEstagio { get; set; }

        public virtual ICollection<DocumentoVersaoModel>? DocumentoVersoes { get; set; }
    }
}