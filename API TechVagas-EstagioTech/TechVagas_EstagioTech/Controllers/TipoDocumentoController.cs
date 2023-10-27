using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
		private readonly ITipoDocumentoService _tipoDocumentoService;

		public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
		{
			_tipoDocumentoService = tipoDocumentoService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarTodosTipoDocumentos();
			if (tipoDocumentoDto == null) return NotFound("Tipos de Documentos não encontrados!");
			return Ok(tipoDocumentoDto);
		}

		[HttpGet("{id:int}", Name = "ObterTipoDocumento")]
		public async Task<ActionResult<DocumentoDto>> Get(int id)
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
			if (tipoDocumentoDto == null) return NotFound("Tipo de Documento não encontrado");
			return Ok(tipoDocumentoDto);
		}

		[HttpPost]
        public async Task<ActionResult<TipoDocumentoModel>> Cadastrar([FromBody] TipoDocumentoModel tipoDocumentoModel)
        {
            TipoDocumentoModel tipoDocumento = await _tipoDocumentoRepositorio.Adicionar(tipoDocumentoModel);
            return Ok(tipoDocumento);
        }

        [HttpPut]
        public async Task<ActionResult<TipoDocumentoModel>> Atualizar([FromBody] TipoDocumentoModel tipoDocumentoModel)
        {
            TipoDocumentoModel tipoDocumento = await _tipoDocumentoRepositorio.Atualizar(tipoDocumentoModel);
            return Ok(tipoDocumento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDocumentoModel>> Apagar(int id)
        {
            bool apagado = await _tipoDocumentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
