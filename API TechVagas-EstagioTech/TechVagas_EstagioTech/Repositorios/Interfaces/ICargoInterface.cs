using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
	public interface ICargoInterface
	{
		Task<List<CargoModel>> BuscarTodosCargos();

		Task<CargoModel> BuscarPorId(int id);

		Task<CargoModel> Adicionar(CargoDto cargoDto);

		Task<CargoModel> Atualizar(CargoDto cargoDto);

		Task<bool> Apagar(int id);
	}
}
