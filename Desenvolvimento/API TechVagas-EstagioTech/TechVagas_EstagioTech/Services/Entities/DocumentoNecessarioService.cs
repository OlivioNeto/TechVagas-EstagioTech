using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class DocumentoNecessarioService : IDocumentoNecessarioService
    {
        private readonly IDocumentoNecessarioRepositorio _documentoNecessarioRepositorio;
        private readonly IMapper _mapper;
        public DocumentoNecessarioService(IDocumentoNecessarioRepositorio documentoNecessarioRepositorio, IMapper mapper)
        {
            _documentoNecessarioRepositorio = documentoNecessarioRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoNecessarioDto> BuscarPorId(int id)
        {
            var documentoNecessario = await _documentoNecessarioRepositorio.BuscarPorId(id);
            return _mapper.Map<DocumentoNecessarioDto>(documentoNecessario);
        }
        public async Task<IEnumerable<DocumentoNecessarioDto>> BuscarTodosDocumentosNecessarios()
        {
            var documentoNecessarios = await _documentoNecessarioRepositorio.BuscarTodosDocumentosNecessarios();
            var documentoNecessariosDTO = _mapper.Map<IEnumerable<DocumentoNecessarioDto>>(documentoNecessarios);

            foreach (var documentoDto in documentoNecessariosDTO)
            {
                var documento = documentoNecessarios.FirstOrDefault(documentoNecessario => documentoNecessario.idDocumentoNecessario == documentoDto.idDocumentoNecessario);
                if (documento != null)
                {
                    documentoDto.TipoDocumento = _mapper.Map<TipoDocumentoDto>(documento.TipoDocumento);
                    documentoDto.TipoEstagio = _mapper.Map<TipoEstagioDto>(documento.TipoEstagio);
                }
            }

            return documentoNecessariosDTO;
        }
        public async Task Adicionar(DocumentoNecessarioDto documentoNecessarioDto)
        {
            var documento = _mapper.Map<DocumentoNecessarioModel>(documentoNecessarioDto);
            await _documentoNecessarioRepositorio.Adicionar(documento);
        }
        public async Task Atualizar(DocumentoNecessarioDto documentoNecessarioDto)
        {
            var documentoNecessario = _mapper.Map<DocumentoNecessarioModel>(documentoNecessarioDto);
            await _documentoNecessarioRepositorio.Atualizar(documentoNecessario);
        }
        public async Task Apagar(int id)
        {
            await _documentoNecessarioRepositorio.Apagar(id);
        }
    }
}
