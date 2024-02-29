using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("documentonecessario")]
    public class DocumentoNecessarioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("documentonecessarioid")]
        public int DocumentoNecessarioId { get; set; }

        public TipoDocumentoModel? TipoDocumentos { get; set; }
        [Column("tipodocumentoid")]
        public int idTipoDocumento { get; set; }

        public TipoEstagioModel? TipoEstagios { get; set; }
        [Column("tipoestagioid")]
        public int idTipoEstagio { get; set; }
    }
}
