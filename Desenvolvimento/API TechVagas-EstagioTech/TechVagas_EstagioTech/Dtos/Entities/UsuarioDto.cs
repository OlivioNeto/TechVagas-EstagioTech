using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    [Table("usuario")]
    public class UsuarioDto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("senha")]
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
