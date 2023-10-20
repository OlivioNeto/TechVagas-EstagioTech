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

        public async Task<DocumentoModel> Adicionar(DocumentoModel documento)
        {
            await _dbContext.Documento.AddAsync(documento);
            await _dbContext.SaveChangesAsync();

            return documento;
        }

        public async Task<DocumentoModel> Atualizar(DocumentoModel documento)
        {
            DocumentoModel DocumentoPorId = await BuscarPorId(documento.idDocumento);

            if (DocumentoPorId == null)
            {
                throw new Exception($"O id: {documento.idDocumento} do Documento não foi encontrado no banco");
            }
            DocumentoPorId.descricaoDocumento = documento.descricaoDocumento;
            DocumentoPorId.documento = documento.documento;
            DocumentoPorId.situacaoDocumento = documento.situacaoDocumento;

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
