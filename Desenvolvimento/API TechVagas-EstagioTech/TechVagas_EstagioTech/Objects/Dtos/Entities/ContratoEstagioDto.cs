using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class ContratoEstagioDto
    {
        [Key]
        public int idContratoEstagio { get; set; }

        [Required(ErrorMessage = "E necessário um Status do Contrato")]

        public bool statusContratoEstagio { get; set; }


        [Required(ErrorMessage = "E necessário uma Nota Final")]

        public string? notaFinal { get; set; }


        [Required(ErrorMessage = "E necessário uma Situação")]
        [MinLength(14)]
        [MaxLength(16)]
        public string? situacao { get; set; }


        [Required(ErrorMessage = "E necessário uma Hora de Entrada")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? horarioEntrada { get; set; }


        [Required(ErrorMessage = "E necessário uma Hora de Saída")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? horarioSaida { get; set; }

        [Required(ErrorMessage = "E necessário uma Data do Inicio")]

        public DateOnly? dataInicio { get; set; }

        [Required(ErrorMessage = "E necessário uma Data do Fim")]

        public DateOnly? dataFim { get; set; }

        [Required(ErrorMessage = "Quantidade do Salario")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? salario { get; set; }

        [Required(ErrorMessage = "Qual a Carga Semanal")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? cargaSemanal { get; set; }

        [Required(ErrorMessage = "Qual a Carga Total")]
        [MinLength(3)]
        [MaxLength(50)]
        public string? cargaTotal { get; set; }

        [JsonIgnore]
        [Column("documento")]
        public ICollection<DocumentoModel>? Documento { get; set; }

        [JsonIgnore]
        public ICollection<CoordenadorEstagioModel>? CoordenadorEstagio { get; set; }

        [JsonIgnore]
        public ICollection<SupervisorEstagioModel>? SupervisorEstagio { get; set; }

        [JsonIgnore]
        public ICollection<TipoEstagioModel>? TipoEstagio { get; set; }

        public int idTipoEstagio { get; set; }
        public int idSupervisorEstagio { get; set; }
        public int idCoordenadorEstagio { get; set; }

    }
}
