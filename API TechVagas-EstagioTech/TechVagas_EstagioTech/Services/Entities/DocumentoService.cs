using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
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
	}
}
