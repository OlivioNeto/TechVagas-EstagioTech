using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class TipoDocumentoService : ITipoDocumentoService
	{
		private readonly ITipoDocumentoRepositorio _tipoDocumentoRepositorio;
		private readonly IMapper _mapper;

		public TipoDocumentoService(ITipoDocumentoRepositorio tipoDocumentoRepositorio, IMapper mapper)
		{
			_tipoDocumentoRepositorio = tipoDocumentoRepositorio;
			_mapper = mapper;
		}

		public async Task<TipoDocumentoDto> BuscarPorId(int id)
		{
			var tipoDocumento = await _tipoDocumentoRepositorio.BuscarPorId(id);
			return _mapper.Map<TipoDocumentoDto>(tipoDocumento);
		}

		public async Task<IEnumerable<TipoDocumentoDto>> BuscarTodosTipoDocumentos()
		{
			var tipoDocumento = await _tipoDocumentoRepositorio.BuscarTodosTipoDocumentos();
			return _mapper.Map<IEnumerable<TipoDocumentoDto>>(tipoDocumento);
		}

		public async Task Adicionar(TipoDocumentoDto tipoDocumentoDto)
		{
			var tipoDocumento = _mapper.Map<TipoDocumentoModel>(tipoDocumentoDto);
			await _tipoDocumentoRepositorio.Adicionar(tipoDocumento);
			tipoDocumentoDto.idTipoDocumento = tipoDocumento.idTipoDocumento;
		}

		public async Task Atualizar(TipoDocumentoDto tipoDocumentoDto)
		{
			var tipoDocumento = _mapper.Map<TipoDocumentoModel>(tipoDocumentoDto);
			await _tipoDocumentoRepositorio.Atualizar(tipoDocumento);
		}

		public async Task Apagar(int id)
		{
			await _tipoDocumentoRepositorio.Apagar(id);
		}
	}
}
