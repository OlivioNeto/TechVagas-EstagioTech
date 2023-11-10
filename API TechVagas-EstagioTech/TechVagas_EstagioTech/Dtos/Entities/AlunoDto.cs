using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class AlunoDto
    {
        public int AlunoId { get; set; }

        public string? Nome { get; set; }

        public int Idade { get; set; }

        public string? Rg { get; set; }

        public Boolean StatusAluno { get; set; }

        public string? NumeroMatricula { get; set; }

        public string? AreaInteresse { get; set; }

        public string? Habilidades { get; set; }

        public string? Experiencias { get; set; }

        public string? DisponibilidadeHorario { get; set; }

        public string? Curriculo { get; set; }

        public string? Cpf { get; set; }

        public string? Cidade { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? NivelEscolaridade { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public string? Endereco { get; set; }

        public string? Genero { get; set; }

        public string? Bairro { get; set; }

        public string? Cep { get; set; }
    }
}
