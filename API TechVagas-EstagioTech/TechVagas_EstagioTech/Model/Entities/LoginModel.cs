using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("login")]
    public class LoginModel
    {
        [Key]
        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }
    }
}
