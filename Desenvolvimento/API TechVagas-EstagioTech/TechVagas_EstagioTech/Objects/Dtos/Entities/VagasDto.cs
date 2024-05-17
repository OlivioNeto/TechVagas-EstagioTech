using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{

    public class VagasDto
    {
        [Key]
        public int VagasId { get; set; }

        public int Quantidade { get; set; }

        public DateOnly DataPublicacao { get; set; }

        public DateOnly DataLimite { get; set; }

        [Required(ErrorMessage = "E necessário uma localidade")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? Localidade { get; set; }

        [Required(ErrorMessage = "E necessário uma descrição")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "E necessário um Titulo")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "E necessário um Localidade de Trabalho")]
        [MinLength(3)]
        [MaxLength(20)]
        public string? LocalidadeTrabalho { get; set; }

        [Required(ErrorMessage = "E necessário um Horário de Entrada")]
        [MinLength(3)]
        [MaxLength(20)]
        public string? HorarioEntrada { get; set; }

        [Required(ErrorMessage = "E necessário um Horário de Saída")]
        [MinLength(3)]
        [MaxLength(20)]
        public string? HorarioSaida { get; set; }

        [Required(ErrorMessage = "E necessário um Total de Horas Semanais")]
        [MinLength(3)]
        [MaxLength(20)]
        public string? TotalHorasSemanis { get; set; }

        [JsonIgnore]
        public ConcedenteDto? Concedente { get; set; }

        [ForeignKey("concedenteid")]
        public int concedenteId { get; set; }

        [JsonIgnore]
        public CargoDto? Cargo { get; set; }

        [ForeignKey("cargoid")]
        public int CargoId { get; set; }
    }
}
