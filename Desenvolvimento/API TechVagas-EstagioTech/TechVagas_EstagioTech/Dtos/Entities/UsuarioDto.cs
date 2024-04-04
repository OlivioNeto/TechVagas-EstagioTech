namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
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
