using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
	public interface ICargoInterface
	{
		Task<List<CargoModel>> BuscarTodosCargos();

		Task<CargoModel> BuscarPorId(int id);

		Task<CargoModel> Adicionar(CargoModel cargo);

		Task<CargoModel> Atualizar(CargoModel cargo);

		Task<bool> Apagar(int id);
	}
}
