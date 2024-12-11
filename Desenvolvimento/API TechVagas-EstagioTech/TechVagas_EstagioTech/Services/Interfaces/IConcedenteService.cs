using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IConcedenteService
    {
        Task<IEnumerable<ConcedenteDto>> BuscarTodosConcedentes();
        Task<ConcedenteDto> BuscarPorId(int id);
        Task Adicionar(ConcedenteDto concedenteDto);
        Task Atualizar(ConcedenteDto concedenteDto);
        Task Apagar(int id);
    }
}
