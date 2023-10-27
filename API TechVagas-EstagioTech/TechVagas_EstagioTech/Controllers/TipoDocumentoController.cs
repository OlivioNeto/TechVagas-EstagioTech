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
		public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
			if (tipoDocumentoDto == null) return NotFound("Tipo de Documento não encontrado");
			return Ok(tipoDocumentoDto);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] TipoDocumentoDto tipoDocumentoDto)
		{
			if (tipoDocumentoDto is null) return BadRequest("Dado inválido!");
			await _tipoDocumentoService.Adicionar(tipoDocumentoDto);
			return new CreatedAtRouteResult("GetTipoDocumento", new { id = tipoDocumentoDto.idTipoDocumento }, tipoDocumentoDto);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put([FromBody] TipoDocumentoDto tipoDocumentoDto)
		{
			if (tipoDocumentoDto is null) return BadRequest("Dado invalido!");
			await _tipoDocumentoService.Atualizar(tipoDocumentoDto);
			return Ok(tipoDocumentoDto);
		}

		[HttpDelete("{id}")]
        public async Task<ActionResult<TipoDocumentoModel>> Apagar(int id)
        {
            bool apagado = await _tipoDocumentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
