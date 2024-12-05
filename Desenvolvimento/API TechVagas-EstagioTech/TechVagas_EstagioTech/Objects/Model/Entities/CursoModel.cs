﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("curso")]
    public class CursoModel
    {
        [Column("cursoid")]
        public int cursoid { get; set; }

        [Column("nomecurso")]
        public string? nomeCurso { get; set; }


        [Column("turnocurso")]
        public string? turnoCurso { get; set; }

        [Column("matriculaid")]
        public ICollection<MatriculaModel>? Matriculas { get; set; }


    }
}
