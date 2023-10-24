using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios
{
	public class CargoRepositorio 
	{
		private readonly DBContext _dbContext;

		public CargoRepositorio(DBContext cargoDBContex)
		{
			_dbContext = cargoDBContex;
		}
		public async Task<CargoModel> BuscarPorId(int id)
		{
			return await _dbContext.Cargos.FirstOrDefaultAsync(x => x.CargoId == id);
		}
		public async Task<List<CargoModel>> BuscarTodosCargos()
		{
			return await _dbContext.Cargos.ToListAsync();
		}
	}
}
