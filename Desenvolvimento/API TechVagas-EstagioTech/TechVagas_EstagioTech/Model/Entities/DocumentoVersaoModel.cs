using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("documentoversao")]
    public class DocumentoVersaoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("documentoversaoid")]
        public int DocumentoVersaoId { get; set; }

        [Column("comentario")]
        public string? Comentario { get; set; }

        [Column("anexo")]
        public string? Anexo { get; set; }

        [Column("data")]
        public DateOnly? Data { get; set; }

        [Column("situacao")]
        public string? Situacao { get; set; }

        public DocumentoModel? Documento { get; set; }
        [Column("documentoid")]
        public int DocumentoId { get; set; }
    }
}
