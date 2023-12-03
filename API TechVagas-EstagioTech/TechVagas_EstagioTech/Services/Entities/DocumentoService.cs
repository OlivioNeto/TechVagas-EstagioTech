using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class DocumentoService : IDocumentoService
	{
		private readonly IDocumentoRepositorio _documentoRepositorio;
		private readonly IMapper _mapper;

		public DocumentoService(IDocumentoRepositorio documentoRepositorio, IMapper mapper)
		{
			_documentoRepositorio = documentoRepositorio;
			_mapper = mapper;
		}

		public async Task<DocumentoDto> BuscarPorId(int id)
		{
			var documento = await _documentoRepositorio.BuscarPorId(id);
			return _mapper.Map<DocumentoDto>(documento);
		}

		public async Task<IEnumerable<DocumentoDto>> BuscarTodosDocumentos()
		{
			var documento = await _documentoRepositorio.BuscarTodosDocumentos();
			return _mapper.Map<IEnumerable<DocumentoDto>>(documento);
		}

        public async Task Adicionar(string descricaoDocumento)
        {
            var documento = new DocumentoModel() { descricaoDocumento = descricaoDocumento }; //mapeamento para converter a dto em model antes
            await _documentoRepositorio.Adicionar(documento);
        }

        public async Task Atualizar(DocumentoDto documentoDto)
		{
			var documento = _mapper.Map<DocumentoModel>(documentoDto);
			await _documentoRepositorio.Atualizar(documento);
		}

		public async Task Apagar(int id)
		{
			await _documentoRepositorio.Apagar(id);
		}
	}
}
