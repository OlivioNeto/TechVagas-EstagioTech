﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class DocumentoVersaoDto
    {
        [Key]
        public int idDocumentoVersao { get; set; }


        [Required(ErrorMessage = "É necessário um comentário")]
        [MinLength(3)]
        [MaxLength(150)]
        public string? Comentario { get; set; }


        [Required(ErrorMessage = "É necessário um anexo")]
        [MinLength(3)]
        [MaxLength(150)]
        public string? Anexo { get; set; }


        [Required(ErrorMessage = "É necessário uma data")]
        public DateOnly? Data { get; set; }

        [Required(ErrorMessage = "É necessário uma situação")]
        [MinLength(3)]
        [MaxLength (150)]
        public string? Situacao { get; set; }

        
        [JsonIgnore]
		public ICollection<DocumentoModel>? Documentos { get; set; }

		public int idDocumento { get; set; }
    }
}
