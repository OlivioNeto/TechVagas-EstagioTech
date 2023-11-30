using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> BuscarTodosUsuarios();
        Task<UsuarioDto> BuscarPorId(int id);
        Task<IEnumerable<UsuarioDto>> BuscarPorEmail(string email);
        Task<UsuarioDto> Login(LoginDto loginDto);
        Task Adicionar(UsuarioDto usuarioDto);
        Task Atualizar(UsuarioDto usuarioDto);
        Task Apagar(int id);
    }
}
