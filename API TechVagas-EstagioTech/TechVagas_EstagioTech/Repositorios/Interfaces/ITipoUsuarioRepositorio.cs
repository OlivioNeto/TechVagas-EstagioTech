using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoUsuarioRepositorio
    {
        Task<IEnumerable<TipoUsuarioModel>> BuscarTodosTipoUsuario();
        Task<TipoUsuarioModel> BuscarPorId(int id);
        Task<TipoUsuarioModel> Adicionar(TipoUsuarioModel tipoUsuarioModel);
        Task<TipoUsuarioModel> Atualizar(TipoUsuarioModel tipoUsuarioModel);
        Task<TipoUsuarioModel> Apagar(int id);
    }
}
