using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ICoordenadorEstagioService
    {
        Task<IEnumerable<CoordenadorEstagioDto>> BuscarTodosCoordenadoresEstagio();
        Task<CoordenadorEstagioDto> BuscarPorId(int id);
        Task Adicionar(CoordenadorEstagioDto coordenadorEstagioDto);
        Task Atualizar(CoordenadorEstagioDto coordenadorEstagioDto);
        Task Apagar(int id);
    }
}
