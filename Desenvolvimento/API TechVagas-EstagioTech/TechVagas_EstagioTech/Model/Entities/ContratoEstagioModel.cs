using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("contratoestagio")]
    public class ContratoEstagioModel
    {
        [Column("ContratoEstagioid")]
        public int contratoestagioId { get; set; }


        [Column("Status do ContratoEstagio")]
        public string? statusContratoEstagio { get; set; }


        [Column("notafinal")]
        public string? notaFinal { get; set; }


        [Column("situacao")]
        public string? situacao { get; set; }


        [Column("Horario de Entrada")]
        public string? horarioEntrada { get; set; }

        [Column("Horario de Saida")]
        public string? horarioSaida { get; set; }

        [Column("datainicio")]
        public string? dataInicio { get; set; }

        [Column("datafim")]
        public string? dataFim { get; set; }

        [Column("salario")]
        public string? salario { get; set; }

        [Column("cargasemanal")]
        public string? cargaSemanal { get; set; }

        [Column("cargatotal")]
        public string? cargaTotal { get; set; }
    }
}
