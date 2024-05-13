using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ISupervisorEstagioService
    {
        Task<IEnumerable<SupervisorEstagioDto>> BuscarTodosSupervisorEstagio();
        Task<SupervisorEstagioDto> BuscarPorId(int id);
        Task Adicionar(bool statusSupervisor);
        Task Atualizar(SupervisorEstagioDto supervisorEstagioDto);
        Task Apagar(int id);
    }
}
