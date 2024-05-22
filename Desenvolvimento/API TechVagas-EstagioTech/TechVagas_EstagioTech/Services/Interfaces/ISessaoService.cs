using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ISessaoService
    {
        Task<IEnumerable<SessaoDto>> GetAll();
        Task<IEnumerable<SessaoDto>> GetOpenSessions();
        Task<IEnumerable<SessaoDto>> GetCloseSessions();
        Task<SessaoDto> GetLastSession(int id);
        Task<SessaoDto> GetByToken(string token);
        Task<UsuarioDto> GetUser(string token);
        Task Create(SessaoDto sessaoDto);
        Task Update(SessaoDto sessaoDto);
        Task Remove(int id);

        Task<IEnumerable<UsuarioDto>> GetOnlineUsers();
        Task<IEnumerable<UsuarioDto>> GetOfflineUsers();
        Task<IEnumerable<SessaoDto>> GetOpenSessionByUser(int id);
    }
}
