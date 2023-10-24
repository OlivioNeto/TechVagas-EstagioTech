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
		public async Task<CargoModel> Adicionar(CargoModel cargo)
		{
			await _dbContext.Cargos.AddAsync(cargo);
			await _dbContext.SaveChangesAsync();

			return cargo;
		}
		public async Task<CargoModel> Atualizar(CargoModel cargo)
		{
			CargoModel CargoPorId = await BuscarPorId(cargo.CargoId);

			if (CargoPorId == null)
			{
				throw new Exception($"O id: {cargo.CargoId} do cargo não foi encontrado no banco");
			}
			CargoPorId.Descricao = cargo.Descricao;

			_dbContext.Cargos.Update(CargoPorId);
			await _dbContext.SaveChangesAsync();

			return CargoPorId;
		}
	}
}
