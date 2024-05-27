using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using AutoMapper.Configuration.Conventions;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ISupervisorEstagioService
    {
        Task<IEnumerable<SupervisorEstagioDto>> BuscarTodosSupervisorEstagio();
        Task<SupervisorEstagioDto> BuscarPorId(int id);
        Task Adicionar(bool statusSupervisor, int concedenteId);
        Task Atualizar(SupervisorEstagioDto supervisorEstagioDto);
        Task Apagar(int id);
    }
}
