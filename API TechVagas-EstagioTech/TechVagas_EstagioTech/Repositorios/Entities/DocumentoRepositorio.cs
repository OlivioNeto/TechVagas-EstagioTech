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
            return await _dbContext.Documento.FirstOrDefaultAsync(x => x.idDocumento == id);
        }

        public async Task<List<DocumentoModel>> BuscarTodosDocumentos()
        {
            return await _dbContext.Documento.ToListAsync();
        }

        public async Task<DocumentoModel> Adicionar(DocumentoModel documentoModel)
        {
            await _dbContext.Documento.AddAsync(documentoModel);
            await _dbContext.SaveChangesAsync();

            return documentoModel;
        }

        public async Task<DocumentoModel> Atualizar(DocumentoModel documentoModel)
        {
            DocumentoModel DocumentoPorId = await BuscarPorId(documentoModel.idDocumento);

            if (DocumentoPorId == null)
            {
                throw new Exception($"O id: {documentoModel.idDocumento} do Documento não foi encontrado no banco");
            }
            DocumentoPorId.descricaoDocumento = documentoModel.descricaoDocumento;
            DocumentoPorId.documento = documentoModel.documento;
            DocumentoPorId.situacaoDocumento = documentoModel.situacaoDocumento;

            _dbContext.Documento.Update(DocumentoPorId);
            await _dbContext.SaveChangesAsync();

            return DocumentoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            DocumentoModel DocumentoPorId = await BuscarPorId(id);

            if (DocumentoPorId == null)
            {
                throw new Exception($"O id: {id} do Documento não foi encontrado no banco");
            }

            _dbContext.Documento.Remove(DocumentoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }      
    }
}
