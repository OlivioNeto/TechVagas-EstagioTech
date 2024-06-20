using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechVagas_EstagioTech.Objects.Interface;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("coordenadorestagio")]
    public class CoordenadorEstagioModel : IStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("coordenadorestagioid")]
        public int idCoordenadorEstagio { get; set; }

        [Column("datacadastro")]
        public DateOnly? dataCadastro { get; set; }

        [Column("nomecoordenador")]
        public string nomeCoordenador { get; set; }

        [Column("statuscoordenadorestagio")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        public virtual ICollection<ApontamentoModel>? Apontamento { get; set; }
        public virtual ICollection<ContratoEstagioModel>? ContratoEstagio { get; set; }
        public virtual ICollection<DocumentoModel>? Documento { get; set; }

    }
}
