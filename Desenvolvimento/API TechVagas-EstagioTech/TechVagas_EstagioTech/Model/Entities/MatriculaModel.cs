using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("matricula")]
    public class MatriculaModel
    {
        [Column("matriculaid")]
        public int MatriculaId { get; set; }

        [Column("numeromatricula")]
        public string NumeroMatricula { get; set; }
    }
}
