﻿using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class ContratoEstagioDto
    {
        [Key]
        public int idContratoEstagio { get; set; }

        [Required(ErrorMessage = "E necessário um Status do Contrato")]
        [MinLength(3)]
        [MaxLength(80)]
        public string? statusContratoEstagio { get; set; }


        [Required(ErrorMessage = "E necessário uma Nota Final")]
        [MinLength(3)]
        [MaxLength(50)]
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
        [MinLength(3)]
        [MaxLength(50)]
        public DateOnly? dataInicio { get; set; }

        [Required(ErrorMessage = "E necessário uma Data do Fim")]
        [MinLength(3)]
        [MaxLength(50)]
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
    }
}
