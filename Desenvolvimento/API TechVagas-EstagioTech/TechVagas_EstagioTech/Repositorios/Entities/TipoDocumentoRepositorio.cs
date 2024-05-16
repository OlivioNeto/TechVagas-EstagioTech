using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
	{
        private readonly DBContext _dbContext;
        public TipoDocumentoRepositorio(DBContext tipoDocumentoDBContext)
        {
            _dbContext = tipoDocumentoDBContext;
        }
        public async Task<TipoDocumentoModel> BuscarPorId(int id)
        {
			return await _dbContext.TipoDocumento.Where(x => x.idTipoDocumento == id).FirstOrDefaultAsync();
		}

        public async Task<List<TipoDocumentoModel>> BuscarTodosTipoDocumentos()
        {
            return await _dbContext.TipoDocumento.ToListAsync();
        }


        public async Task<TipoDocumentoModel> Adicionar(TipoDocumentoModel tipoDocumentoModel)
        {

			_dbContext.TipoDocumento.Add(tipoDocumentoModel);
			await _dbContext.SaveChangesAsync();
			return tipoDocumentoModel;
		}

        public async Task<TipoDocumentoModel> Atualizar(TipoDocumentoModel tipoDocumentoModel)
        {
			_dbContext.Entry(tipoDocumentoModel).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return tipoDocumentoModel;
		}

        public async Task<bool> Apagar(int id)
        {
			var tipoDocumento = await BuscarPorId(id);
			_dbContext.TipoDocumento.Remove(tipoDocumento);
			await _dbContext.SaveChangesAsync();
			return true;
		}        
    }
}
