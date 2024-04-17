using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("contratoestagio")]
    public class ContratoEstagioModel
    {
        [Column("ContratoEstagioid")]
        public int idContratoEstagio { get; set; }


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
        public DateOnly? dataInicio { get; set; }

        [Column("datafim")]
        public DateOnly? dataFim { get; set; }

        [Column("salario")]
        public string? salario { get; set; }

        [Column("cargasemanal")]
        public string? cargaSemanal { get; set; }

        [Column("cargatotal")]
        public string? cargaTotal { get; set; }

        public CoordenadorEstagioModel? CoordenadorEstagio { get; set; }
        [Column("coordenadorestagioid")]
        public int idCoordenadorEstagio { get; set; }

        public SupervisorEstagioModel? SupervisorEstagio { get; set; }
        [Column("supervisorestagioid")]
        public int idSupervisorEstagio { get; set; }

        public TipoEstagioModel? TipoEstagio { get; set; }
        [Column("tipoestagioid")]
        public int idTipoEstagio { get; set; }


    }
}
