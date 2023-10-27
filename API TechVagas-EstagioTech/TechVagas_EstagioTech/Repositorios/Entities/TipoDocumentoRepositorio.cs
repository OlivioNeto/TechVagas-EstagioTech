using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
	{
        private readonly DBContext _dbContex;
        public TipoDocumentoRepositorio(DBContext tipoDocumentoDBContext)
        {
            _dbContex = tipoDocumentoDBContext;
        }
        public async Task<TipoDocumentoModel> BuscarPorId(int id)
        {
            return await _dbContex.TipoDocumento.FirstOrDefaultAsync(x => x.idTipoDocumento == id);
        }

        public async Task<List<TipoDocumentoModel>> BuscarTodosTipoDocumentos()
        {
            return await _dbContex.TipoDocumento.ToListAsync();
        }


        public async Task<TipoDocumentoModel> Adicionar(TipoDocumentoModel tipoDocumentoModel)
        {
            await _dbContex.TipoDocumento.AddAsync(tipoDocumentoModel);
            await _dbContex.SaveChangesAsync();

            return tipoDocumentoModel;
        }

        public async Task<TipoDocumentoModel> Atualizar(TipoDocumentoModel tipoDocumentoModel)
        {
            TipoDocumentoModel tipoDocumentoPorId = await BuscarPorId(tipoDocumentoModel.idTipoDocumento);

            if (tipoDocumentoPorId == null)
            {
                throw new Exception($"O id: {tipoDocumentoModel.idTipoDocumento} do tipo documento não foi encontrado no banco");
            }
            tipoDocumentoPorId.descricaoTipoDocumento = tipoDocumentoModel.descricaoTipoDocumento;

            _dbContex.TipoDocumento.Update(tipoDocumentoPorId);
            await _dbContex.SaveChangesAsync();

            return tipoDocumentoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoDocumentoModel tipoDocumentoPorId = await BuscarPorId(id);

            if (tipoDocumentoPorId == null)
            {
                throw new Exception($"O id: {id} do tipo documento não foi encontrado no banco");
            }
            _dbContex.TipoDocumento.Remove(tipoDocumentoPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }        
    }
}
