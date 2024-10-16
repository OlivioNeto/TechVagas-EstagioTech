using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("documentoversao")]
    public class DocumentoVersaoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("documentoversaoid")]
        public int idDocumentoVersao { get; set; }

        [Column("comentario")]
        public string? comentario { get; set; }

        [Column("anexo")]
        public string? anexo { get; set; }

        [Column("data")]
        public DateOnly? data { get; set; }

        [Column("situacao")]
        public string? situacao { get; set; }

        public DocumentoModel? Documento { get; set; }
        [Column("documentoid")]
        public int idDocumento { get; set; }
    }
}
