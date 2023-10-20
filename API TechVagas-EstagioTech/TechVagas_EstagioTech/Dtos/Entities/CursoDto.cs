using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class CursoDto
	{
		public int idCurso { get; set; }

		[Required(ErrorMessage = "E necessário o nome do curso")]
		[MinLength(3)]
		[MaxLength(200)]
		public string nomeCurso { get; set; }
	}
}
