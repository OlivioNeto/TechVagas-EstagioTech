using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("usuario")]
    public class UsuarioModel
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
        Administrador,
        Aluno,
        Coordenador,
        Empresa
    }
}

