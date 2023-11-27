using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class DocumentoDto
	{
        [Key]
        [JsonIgnore]
        public int DocumentoId { get; set; }

		[Required(ErrorMessage = "Informe a descrição do documento")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? descricaoDocumento { get; set; }


		[Required(ErrorMessage = "Informe a situação do documento")]
		public string? situacaoDocumento { get; set; }
	}
}
