using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class TipoEstagioDto
	{
        [Key]
        public int idTipoEstagio { get; set; }

		[Required(ErrorMessage = "Informe a descrição do tipo do estágio")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? descricaoTipoEstagio { get; set; }
	}
}
