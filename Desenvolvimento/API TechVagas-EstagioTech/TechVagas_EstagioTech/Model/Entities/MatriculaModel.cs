using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("matricula")]
    public class MatriculaModel
    {
        [Column("matriculaid")]
        public int MatriculaId { get; set; }

        [Column("numeromatricula")]
        public string NumeroMatricula { get; set; }

        //[Column("alunos")]
        //public ICollection<AlunoModel>? Alunos { get; set; }

        //[Column("cursos")]
        //public ICollection<CursoModel>? Cursos { get; set; }


    }
}
