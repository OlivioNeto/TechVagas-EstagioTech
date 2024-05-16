using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
		private readonly IDocumentoService _documentoService;

		public DocumentoController(IDocumentoService documentoService)
		{
			_documentoService = documentoService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<DocumentoDto>>> Get()
		{
			var documentoDto = await _documentoService.BuscarTodosDocumentos();
			if (documentoDto == null) return NotFound("Documentos não encontrados!");
			return Ok(documentoDto);
		}

		[HttpGet("{id:int}", Name = "ObterDocumento")]
		public async Task<ActionResult<DocumentoDto>> Get(int id)
		{
			var documentoDto = await _documentoService.BuscarPorId(id);
			if (documentoDto == null) return NotFound("Documento não encontrado");
			return Ok(documentoDto);
		}


		[HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentoDto documentoDto)
        {
            if (documentoDto is null) return BadRequest("Dado inválido!");
            await _documentoService.Adicionar(documentoDto);
            return Ok("Dado cadastrado com sucesso");
        }

		[HttpPut]
		public async Task<ActionResult> Put( [FromBody] DocumentoDto documentoDto)
		{
			if (documentoDto is null ) return BadRequest("Dado invalido!");
			await _documentoService.Atualizar(documentoDto);
			return Ok(documentoDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<DocumentoDto>> Delete(int id)
		{
			var documentoDto = await _documentoService.BuscarPorId(id);
			if (documentoDto == null) return NotFound("Documento não econtrado!");
			await _documentoService.Apagar(id);
			return Ok(documentoDto);
		}
	}
}
