using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("supervisorestagio")]
    public class SupervisorEstagioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("supervisorid")]
        public int idSupervisor { get; set; }

        [Column("status")]
        public bool statusSupervisor { get; set; }

        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }
    }
}