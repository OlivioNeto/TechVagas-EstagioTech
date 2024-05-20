using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("supervisorestagio")]
    public class SupervisorEstagioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        public int ConcedenteId { get; set; }
        public ConcedenteModel Concedente { get; set; }


        [Column("supervisorid")]
        public int idSupervisor { get; set; }

        [Column("status")]
        public bool statusSupervisor { get; set; }

        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }
    }
}