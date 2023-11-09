using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class DocumentoDto
	{
        [Key]
        public int idDocumento { get; set; }

		[Required(ErrorMessage = "Informe a descrição do documento")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? descricaoDocumento { get; set; }

		[Required(ErrorMessage = "Informe o documento")]
		public string? documento { get; set; }

		[Required(ErrorMessage = "Informe a situação do documento")]
		public string? situacaoDocumento { get; set; }
	}
}
