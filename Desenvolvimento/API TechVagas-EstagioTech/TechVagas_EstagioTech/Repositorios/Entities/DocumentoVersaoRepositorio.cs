using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class DocumentoVersaoRepositorio : IDocumentoVersaoRepositorio
    {
        
        private readonly DBContext _dbContext;
        public DocumentoVersaoRepositorio(DBContext documentoVersaoDBContext)
        {
            _dbContext = documentoVersaoDBContext;
        }
        public async Task<DocumentoVersaoModel> BuscarPorId(int id)
        {
            return await _dbContext.DocumentoVersao.Where(x=> x.idDocumentoVersao == id).FirstOrDefaultAsync();
        }
        public async Task<List<DocumentoVersaoModel>> BuscarTodasVersoesDocumentos()
        {
            return await _dbContext.DocumentoVersao.ToListAsync(); 
        }
        public async Task<DocumentoVersaoModel> Adicionar(DocumentoVersaoModel documentoVersaoModel)
        {
            _dbContext.DocumentoVersao.Add(documentoVersaoModel);
            await _dbContext.SaveChangesAsync();
            return documentoVersaoModel;

        }
        public async Task<DocumentoVersaoModel> Atualizar(DocumentoVersaoModel documentoVersaoModel)
        {
            _dbContext.Entry(documentoVersaoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return documentoVersaoModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var documentoVersao = await BuscarPorId(id);
            _dbContext.DocumentoVersao.Remove(documentoVersao);
            await _dbContext.SaveChangesAsync();
            return true;
        } 
    }
}
