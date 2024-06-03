using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("supervisorestagio")]
    public class SupervisorEstagioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("supervisorid")]
        public int idSupervisor { get; set; }

        [Column("nomesupervisor")]
        public string nomeSupervisor { get; set; }

        [Column("status")]
        public bool statusSupervisor { get; set; }      

        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }
    }
}