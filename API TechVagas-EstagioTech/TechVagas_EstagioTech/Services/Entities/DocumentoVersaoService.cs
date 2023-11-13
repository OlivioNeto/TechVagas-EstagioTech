using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
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
        public async Task<IEnumerable<DocumentoVersaoDto>> BuscarTodosTipoDocumentos()
        {
            var documentoVersao = await _documentoVersaoRepositorio.BuscarTodasVersoesDocumentos();
            return _mapper.Map<IEnumerable<DocumentoVersaoDto>>(documentoVersao);
        }
        public async Task Adicionar(string comentario)
        {

            var documentoVersao = new DocumentoVersaoModel() { Comentario = comentario };
            await _documentoVersaoRepositorio.Adicionar(documentoVersao);
        }

        public async Task Atualizar(DocumentoVersaoDto documentoVersaoDto)
        {
            var documentoVersao = _mapper.Map<DocumentoVersaoModel>(documentoVersaoDto);
            await _documentoVersaoRepositorio.Atualizar(documentoVersao);
        }

        public async Task Apagar(int id)
        {
            await _documentoVersaoRepositorio.Apagar(id);
        }   
    }
}
