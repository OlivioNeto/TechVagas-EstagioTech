using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class DocumentoRepositorio : IDocumentoRepositorio
    {
        private readonly DBContext _dbContext;
        public DocumentoRepositorio(DBContext documentoDBContex)
        {
            _dbContext = documentoDBContex;
        }

        public async Task<DocumentoModel> BuscarPorId(int id)
        {
			return await _dbContext.Documento.Where(x => x.DocumentoId == id).FirstOrDefaultAsync();
		}

        public async Task<List<DocumentoModel>> BuscarTodosDocumentos()
        {
            return await _dbContext.Documento.ToListAsync();
        }

        public async Task<DocumentoModel> Adicionar(DocumentoModel documentoModel)
        {
			_dbContext.Documento.Add(documentoModel);
			await _dbContext.SaveChangesAsync();
			return documentoModel;
		}

        public async Task<DocumentoModel> Atualizar(DocumentoModel documentoModel)
        {
			_dbContext.Entry(documentoModel).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return documentoModel;
		}

        public async Task<bool> Apagar(int id)
        {
			var documento = await BuscarPorId(id);
			_dbContext.Documento.Remove(documento);
			await _dbContext.SaveChangesAsync();
			return true;
		}      
    }
}
