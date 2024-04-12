using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("apontamento")]
    public class ApontamentoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //coluna de id gerada automitacamente
        [Key] //define como chave primaria

        [Column("apontamentoid")]
        public int idApontamento { get; set; }

        [Column("descricaoApontamento")]
        public string? descricaoApontamento { get; set; }

        [Column("dataApontamento")]
        public DateOnly? dataApontamento { get; set; }

        public CoordenadorEstagioModel? CoordenadorEstagio { get; set; }
        [Column("coordenadorestagioid")]
        public int idCoordenadorEstagio { get; set; }
    }
}
