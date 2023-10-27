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
			await _dbContext.Cargos.AddAsync(cargoModel);
			await _dbContext.SaveChangesAsync();

			return cargoModel;
		}
		public async Task<CargoModel> Atualizar(CargoModel cargoModel)
		{
			CargoModel CargoPorId = await BuscarPorId(cargoModel.CargoId);

			if (CargoPorId == null)
			{
				throw new Exception($"O id: {cargoModel.CargoId} do cargo não foi encontrado no banco");
			}
			CargoPorId.Descricao = cargoModel.Descricao;

			_dbContext.Cargos.Update(CargoPorId);
			await _dbContext.SaveChangesAsync();

			return CargoPorId;
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
