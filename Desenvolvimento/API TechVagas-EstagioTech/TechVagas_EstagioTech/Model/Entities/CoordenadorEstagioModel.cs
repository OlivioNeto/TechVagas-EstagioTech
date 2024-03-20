using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("coordenadorestagio")]
    public class CoordenadorEstagioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("coordenadorestagioid")]
        public int idCoordenadorEstagio { get; set; }

        [Column("datacadastro")]
        public DateOnly dataCadastro { get; set; }

        [Column("statuscoordenador")]
        public string? StatusCoordenadorEstagio { get; set; }

        public virtual ICollection<ApontamentoModel>? Apontamento { get; set; }
    }
}
