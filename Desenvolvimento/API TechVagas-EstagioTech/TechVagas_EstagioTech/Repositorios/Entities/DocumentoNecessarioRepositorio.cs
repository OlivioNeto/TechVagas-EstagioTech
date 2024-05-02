using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class DocumentoNecessarioRepositorio : IDocumentoNecessarioRepositorio
    {
        private readonly DBContext _dbContext;
        public DocumentoNecessarioRepositorio(DBContext documentoNecessarioDBContext)
        {
            _dbContext = documentoNecessarioDBContext;
        }
        public async Task<DocumentoNecessarioModel> BuscarPorId(int id)
        {
            return await _dbContext.DocumentoNecessario.Where(x => x.idDocumentoNecessario == id).FirstOrDefaultAsync();
        }
        public async Task<List<DocumentoNecessarioModel>> BuscarTodosDocumentosNecessarios()
        {
            return await _dbContext.DocumentoNecessario.Include(documentoNecessario => documentoNecessario.TipoDocumento).Include(documentoNecessario => documentoNecessario.TipoEstagio).ToListAsync();
        }

        public async Task<DocumentoNecessarioModel> Adicionar(DocumentoNecessarioModel documentoNecessarioModel)
        {
            _dbContext.DocumentoNecessario.Add(documentoNecessarioModel);
            await _dbContext.SaveChangesAsync();
            return documentoNecessarioModel;
        }
        public async Task<DocumentoNecessarioModel> Atualizar(DocumentoNecessarioModel documentoNecessarioModel)
        {
            _dbContext.Entry(documentoNecessarioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return documentoNecessarioModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var documentoNecessario = await BuscarPorId(id);
            _dbContext.DocumentoNecessario.Remove(documentoNecessario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
