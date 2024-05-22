using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ISessaoRepositorio
    {
        Task<IEnumerable<SessaoModel>> GetAll();
        Task<IEnumerable<IEnumerable<SessaoModel>>> GetAllSessionsGroupedByUser();
        Task<IEnumerable<SessaoModel>> GetOpenSessions();
        Task<IEnumerable<SessaoModel>> GetCloseSessions();
        Task<SessaoModel> GetLastSession(int id);
        Task<SessaoModel> GetById(int id);
        Task<SessaoModel> GetByToken(string token);
        Task<UsuarioModel> GetUser(string token);
        Task<SessaoModel> Create(SessaoModel sessaoModel);
        Task<SessaoModel> Update(SessaoModel sessaoModel);
        Task<SessaoModel> Delete(int id);

        Task<IEnumerable<UsuarioModel>> GetOnlineUsers();
        Task<IEnumerable<UsuarioModel>> GetOfflineUsers();
        Task<IEnumerable<SessaoModel>> GetOpenSessionByUser(int id);
    }
}
