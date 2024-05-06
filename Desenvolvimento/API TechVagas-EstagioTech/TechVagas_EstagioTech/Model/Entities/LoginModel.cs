using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("login")]
    public class LoginModel
    {
        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }
    }
    public class ValidacaoModel
    {
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
