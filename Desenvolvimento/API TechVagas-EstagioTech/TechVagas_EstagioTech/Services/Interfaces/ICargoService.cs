using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoDto>> BuscarTodosCargos();
        Task<CargoDto> BuscarPorId(int id);
        Task Adicionar(CargoDto cargoDto);
        Task Atualizar(CargoDto cargoDto);
        Task Apagar(int id);
    }
}
