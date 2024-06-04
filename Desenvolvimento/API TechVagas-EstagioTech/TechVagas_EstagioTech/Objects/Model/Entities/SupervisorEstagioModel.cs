using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Objects.Interface;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("supervisorestagio")]
    public class SupervisorEstagioModel : IStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("supervisorid")]
        public int idSupervisor { get; set; }

        [Column("nomesupervisor")]
        public string nomeSupervisor { get; set; }

        [Column("statussupervisorestagio")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);


        //Chaves estrangeiras

        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }

        public ConcedenteModel? Concedente { get; set; }
        [Column("concedenteid")]
        public int concedenteId { get; set; }
    }
}