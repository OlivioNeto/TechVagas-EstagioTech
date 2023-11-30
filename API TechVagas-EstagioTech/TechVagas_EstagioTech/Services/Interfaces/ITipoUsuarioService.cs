using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<IEnumerable<TipoUsuarioDto>> BuscarTodosTipoUsuario();
        Task<TipoUsuarioDto> BuscarPorId(int id);
        Task Adicionar(TipoUsuarioDto tipoUsuarioDto);
        Task Atualizar(TipoUsuarioDto tipoUsuarioDto);
        Task Apagar(int id);
    }
}
