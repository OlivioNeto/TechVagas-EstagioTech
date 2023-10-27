using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
	public class CargoRepositorio : ICargoRepositorio
	{
		private readonly DBContext _dbContext;

		public CargoRepositorio(DBContext cargoDBContex)
		{
			_dbContext = cargoDBContex;
		}
		public async Task<CargoModel> BuscarPorId(int id)
		{
			return await _dbContext.Cargos.Where(x => x.CargoId == id).FirstOrDefaultAsync();
		}
		public async Task<List<CargoModel>> BuscarTodosCargos()
		{
			return await _dbContext.Cargos.ToListAsync();
		}
		public async Task<CargoModel> Adicionar(CargoModel cargoModel)
		{
			_dbContext.Cargos.Add(cargoModel);
			await _dbContext.SaveChangesAsync();
			return cargoModel;
		}
		public async Task<CargoModel> Atualizar(CargoModel cargoModel)
		{
			_dbContext.Entry(cargoModel).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return cargoModel;
		}
		public async Task<bool> Apagar(int id)
		{
			CargoModel CargoPorId = await BuscarPorId(id);

			if (CargoPorId == null)
			{
				throw new Exception($"O id: {id} do cargo não foi encontrado no banco");
			}

			_dbContext.Cargos.Remove(CargoPorId);
			await _dbContext.SaveChangesAsync();
			return true;
		}

    }
}
