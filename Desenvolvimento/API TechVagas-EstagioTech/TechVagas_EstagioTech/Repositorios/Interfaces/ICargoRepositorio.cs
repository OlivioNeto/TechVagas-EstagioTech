using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICargoRepositorio
	{
		Task<List<CargoModel>> BuscarTodosCargos();

		Task<CargoModel> BuscarPorId(int id);

		Task<CargoModel> Adicionar(CargoModel cargoModel);

		Task<CargoModel> Atualizar(CargoModel cargoModel);

		Task<bool> Apagar(int id);
	}
}
