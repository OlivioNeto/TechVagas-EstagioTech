using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("tipodocumento")]
    public class TipoDocumentoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("tipodocumentoid")]
        public int idTipoDocumento { get; set; }

        [Column("descricao")]
        public string? descricaoTipoDocumento { get; set; }

        public virtual ICollection<DocumentoNecessarioModel>? DocumentosNecessarios { get; set; }
    }
}