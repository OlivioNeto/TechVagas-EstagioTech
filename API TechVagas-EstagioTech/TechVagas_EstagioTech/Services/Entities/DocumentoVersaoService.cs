using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class DocumentoVersaoService : IDocumentoVersaoService
    {
        private readonly IDocumentoVersaoRepositorio _documentoVersaoRepositorio; 
        private readonly IMapper _mapper;

        public DocumentoVersaoService(IDocumentoVersaoRepositorio documentoVersaoRepositorio, IMapper mapper)
        {
            _documentoVersaoRepositorio = documentoVersaoRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoVersaoDto> BuscarPorId(int id)
        {
            var documentoVersao = await _documentoVersaoRepositorio.BuscarPorId(id);
            return _mapper.Map<DocumentoVersaoDto>(documentoVersao);
        }
        public Task Adicionar(string comentario)
        {
            throw new NotImplementedException();
        }

        public Task Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(DocumentoVersaoDto documentoVersaoDto)
        {
            throw new NotImplementedException();
        }

        

        public Task<IEnumerable<DocumentoVersaoDto>> BuscarTodosTipoDocumentos()
        {
            throw new NotImplementedException();
        }
    }
}
