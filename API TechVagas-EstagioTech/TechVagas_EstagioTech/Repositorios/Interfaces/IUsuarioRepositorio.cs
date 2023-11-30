using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<IEnumerable<UsuarioModel>> BuscarPorEmail(string email);
        Task<UsuarioModel> Login(LoginModel login);
        Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Apagar(int id);
    }
}
