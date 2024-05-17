using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<UsuarioModel> BuscarPorId(int id);
        Task<List<UsuarioModel>> BuscarUsuario();
        Task<UsuarioModel> BuscarPorNome(string email);
        Task<UsuarioModel> Adicionar(UsuarioModel Usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel Usuario, int id);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> Autenticacao(LoginModel loginModel);
    }
}
