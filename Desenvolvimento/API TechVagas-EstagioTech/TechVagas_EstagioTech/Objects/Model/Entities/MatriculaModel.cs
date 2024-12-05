﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("matricula")]
    public class MatriculaModel
    {
        [Column("matriculaid")]
        public int MatriculaId { get; set; }

        [Column("numeromatricula")]
        public string NumeroMatricula { get; set; }

        public AlunoModel? Alunos { get; set; }
        [Column("alunoid")]
        public int AlunoId { get; set; }

        public CursoModel? Curso { get; set; }
        [Column("cursoid")]
        public int cursoid { get; set; }

        public ICollection<ContratoEstagioModel>? ContratosEstagio { get; set; }
    }
}
