
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("aluno")]
    public class AlunoModel
    {
        [Column("alunoid")]
        public int AlunoId { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("idade")]
        public int Idade { get; set; }

        [Column("rg")]
        public string? Rg { get; set; }

        [Column("statusaluno")]
        public Boolean StatusAluno { get; set; }

        [Column("numeromatricula")]
        public string? NumeroMatricula { get; set; }

        [Column("areainteresse")]
        public string? AreaInteresse { get; set; }

        [Column("habilidades")]
        public string? Habilidades { get; set; }

        [Column("experiencias")]
        public string? Experiencias { get; set; }

        [Column("disponibilidadehorario")]
        public string? DisponibilidadeHorario { get; set; }

        [Column("curriculo")]
        public string? Curriculo { get; set; }

        [Column("cpf")]
        public string? Cpf { get; set; }

        [Column("cidade")]
        public string? Cidade { get; set; }

        [Column("datanascimento")]
        public DateOnly DataNascimento { get; set; }

        [Column("nivelescolaridade")]
        public string? NivelEscolaridade { get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("endereco")]
        public string? Endereco { get; set; }

        [Column("genero")]
        public string? Genero { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("cep")]
        public string? Cep { get; set; }


    }
}
