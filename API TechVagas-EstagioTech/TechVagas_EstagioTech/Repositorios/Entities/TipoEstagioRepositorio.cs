using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class TipoEstagioRepositorio : ITipoEstagioRepositorio
    {
        private readonly AppDbContext _dbContext;
        public TipoEstagioRepositorio(AppDbContext tipoEstagioDBContex)
        {
            _dbContext = tipoEstagioDBContex;
        }

        public async Task<TipoEstagioModel> BuscarPorId(int id)
        {
			return await _dbContext.TipoEstagio.Where(x => x.idTipoEstagio == id).FirstOrDefaultAsync();
		}

        public async Task<List<TipoEstagioModel>> BuscarTodosTipoEstagio()
        {
            return await _dbContext.TipoEstagio.ToListAsync();
        }

        public async Task<TipoEstagioModel> Adicionar(TipoEstagioModel tipoEstagioModel)
        {
			_dbContext.TipoEstagio.Add(tipoEstagioModel);
			await _dbContext.SaveChangesAsync();
			return tipoEstagioModel;
		}

        public async Task<TipoEstagioModel> Atualizar(TipoEstagioModel tipoEstagioModel)
        {
			_dbContext.Entry(tipoEstagioModel).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return tipoEstagioModel;
		}

        public async Task<bool> Apagar(int id)
        {
			var tipoEstagio = await BuscarPorId(id);
			_dbContext.TipoEstagio.Remove(tipoEstagio);
			await _dbContext.SaveChangesAsync();
			return true;
		}        
    }
}
