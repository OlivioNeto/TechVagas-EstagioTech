using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class UsuarioDto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        public UserType Type { get; set; }
    }

    public enum UserType
    {
        Administrador = 1,
        Aluno = 2,
        Coordenador = 3,
        Empresa = 4
    }
}
