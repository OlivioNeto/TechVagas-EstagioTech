using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
	public interface ICargoInterface
	{
		Task<List<CargoModel>> BuscarTodosCargos();
	}
}
