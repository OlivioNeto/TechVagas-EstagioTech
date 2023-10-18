using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
    {
        private readonly DBContex _dbContex;
        public TipoDocumentoRepositorio(DBContex tipoDocumentoDBContext)
        {
            _dbContex = tipoDocumentoDBContext;
        }
        public async Task<TipoDocumentoModel> BuscarPorId(int id)
        {
            return await _dbContex.TipoDocumento.FirstOrDefaultAsync(x => x.idTipoDocumento == id);
        }

        public async Task<List<TipoDocumentoModel>> BuscarTodosTiposDocumentos()
        {
            return await _dbContex.TipoDocumento.ToListAsync();
        }


        public async Task<TipoDocumentoModel> Adicionar(TipoDocumentoModel tipoDocumento)
        {
            await _dbContex.TipoDocumento.AddAsync(tipoDocumento);
            await _dbContex.SaveChangesAsync();

            return tipoDocumento;
        }

        public async Task<TipoDocumentoModel> Atualizar(TipoDocumentoModel tipoDocumento)
        {
            TipoDocumentoModel tipoDocumentoPorId = await BuscarPorId(tipoDocumento.idTipoDocumento);

            if (tipoDocumentoPorId == null)
            {
                throw new Exception($"O id: {tipoDocumento.idTipoDocumento} do tipo documento não foi encontrado no banco");
            }
            tipoDocumentoPorId.descricaoTipoDocumento = tipoDocumento.descricaoTipoDocumento;

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
