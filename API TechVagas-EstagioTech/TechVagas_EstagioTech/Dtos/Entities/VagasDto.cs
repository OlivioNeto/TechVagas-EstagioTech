using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    [Table("vagas")]
    public class VagasDto
    {
        [Key]
        [Column("vagasid")]
        public int VagasId { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("datapublicacao")]
        public DateTime DataPublicacao { get; set; }

        [Column("datalimite")]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "E necessário uma localidade")]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("localidade")]
        public string? Localidade { get; set; }

        [Required(ErrorMessage = "E necessário uma descrição")]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("descricao")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "E necessário um Titulo")]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("titulo")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "E necessário um Localidade de Trabalho")]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("localidadetrabalho")]
        public string? LocalidadeTrabalho { get; set; }

        [Required(ErrorMessage = "E necessário um Horário de Entrada")]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("horarioentrada")]
        public string? HorarioEntrada { get; set; }

        [Required(ErrorMessage = "E necessário um Horário de Saída")]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("horariosaida")]
        public string? HorarioSaida { get; set; }

        [Required(ErrorMessage = "E necessário um Total de Horas Semanais")]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("totalhorassemanais")]
        public string? TotalHorasSemanis { get; set; }

        [JsonIgnore]
        public CargoDto? CargoDto { get; set; }

        [ForeignKey("cargoid")]
        public int CargoId { get; set; }
    }
}
