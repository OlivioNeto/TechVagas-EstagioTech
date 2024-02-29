using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("documento")]
    public class DocumentoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("documentoid")]
        public int DocumentoId { get; set; }

        [Column("descricao")]
        public string? descricaoDocumento { get; set; }

        [Column("situacao")]
        public string? situacaoDocumento { get; set; }

        public virtual ICollection<DocumentoVersaoModel>? DocumentoVersoes { get;  set; }
    }
}