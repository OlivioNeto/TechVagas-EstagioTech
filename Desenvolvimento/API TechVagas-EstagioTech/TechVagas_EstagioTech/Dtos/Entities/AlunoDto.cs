using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class AlunoDto
    {
		[Key]
		public int AlunoId { get; set; }

		[Required(ErrorMessage = "E necessário um nome")]
		[MinLength(3)]
		[MaxLength(150)]

		public string? Nome { get; set; }

		[Required(ErrorMessage = "E necessário uma idade")]
		public int Idade { get; set; }


		[Required(ErrorMessage = "E necessário um Rg")]
		[MinLength(7)]
		[MaxLength(12)]
		public string? Rg { get; set; }

		[Required(ErrorMessage = "E necessário um status")]
		public Boolean StatusAluno { get; set; }


		[Required(ErrorMessage = "E necessário um Numero Matricula")]
		[MaxLength(50)]
		public string? NumeroMatricula { get; set; }

		[Required(ErrorMessage = "E necessário uma aréa de interesse ")]
		[MaxLength(100)]
		public string? AreaInteresse { get; set; }


		[Required(ErrorMessage = "E necessário informar as suas habilidades")]
		[MaxLength(100)]
		public string? Habilidades { get; set; }


		[Required(ErrorMessage = "E necessário informar suas experiencias")]
		[MaxLength(350)]
		public string? Experiencias { get; set; }


		[Required(ErrorMessage = "E necessário informar sua disponibilidade de horário")]
		[MaxLength(35)]
		public string? DisponibilidadeHorario { get; set; }

		[Required(ErrorMessage = "E necessário anexar seu curriculo")]
		public string? Curriculo { get; set; }

		[Required(ErrorMessage = "E necessário inserir seu Cpf")]
		[MinLength(11)]
		[MaxLength(14)]
		public string? Cpf { get; set; }


		[Required(ErrorMessage = "E necessário informar uma cidade")]
		[MinLength(3)]
		[MaxLength(50)]
		public string? Cidade { get; set; }

        public DateTime DataNascimento { get; set; }


		[Required(ErrorMessage = "E necessário informar seu nivel de escolaridade")]
		[MinLength(3)]
		[MaxLength(80)]
		public string? NivelEscolaridade { get; set; }


		[Required(ErrorMessage = "E necessário informar seu telefone")]
		[MinLength(11)]
		[MaxLength(14)]
		public string? Telefone { get; set; }

		[Required(ErrorMessage = "E necessário informar seu email")]
		[MinLength(3)]
		[MaxLength(50)]
		public string? Email { get; set; }

		[Required(ErrorMessage = "E necessário informar seu endereco")]
		[MinLength(3)]
		[MaxLength(50)]
		public string? Endereco { get; set; }


		[Required(ErrorMessage = "E necessário informar seu genero")]
		[MinLength(3)]
		[MaxLength(30)]
		public string? Genero { get; set; }

		[Required(ErrorMessage = "E necessário informar seu Bairro")]
		[MinLength(3)]
		[MaxLength(30)]
		public string? Bairro { get; set; }


		[Required(ErrorMessage = "E necessário informar seu Bairro")]
		[MinLength(8)]
		[MaxLength(9)]
		public string? Cep { get; set; }

        [Column("matricula")]
        public ICollection<MatriculaModel>? Matricula { get; set; }
    }
}
