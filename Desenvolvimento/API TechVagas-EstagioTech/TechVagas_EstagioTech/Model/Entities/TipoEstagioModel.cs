using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("tipoestagio")]
    public class TipoEstagioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("tipoestagioid")]
        public int idTipoEstagio { get; set; }

        [Column("descricao")]
        public string? descricaoTipoEstagio { get; set; }

        public virtual ICollection<DocumentoNecessarioModel>? DocumentosNecessarios { get; set; }

        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }
    }
}