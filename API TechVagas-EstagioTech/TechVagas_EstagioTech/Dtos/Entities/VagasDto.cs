using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    
    public class VagasDto
    {
        [Key]
        
        public int VagasId { get; set; }

        public int Quantidade { get; set; }
    
        public DateTime DataPublicacao { get; set; }
        
        public DateTime DataLimite { get; set; }

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

        public ICollection<CargoDto>? CargoDto { get; set; }
    }
}
