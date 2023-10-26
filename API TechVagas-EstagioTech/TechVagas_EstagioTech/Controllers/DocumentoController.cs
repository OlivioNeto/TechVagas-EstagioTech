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
        public async Task<ActionResult<DocumentoModel>> Cadastrar([FromBody] DocumentoModel DocumentoModel)
        {
            DocumentoModel documento = await _documento.Adicionar(DocumentoModel);
            return Ok(documento);
        }

        [HttpPut]
        public async Task<ActionResult<DocumentoModel>> Atualizar([FromBody] DocumentoModel DocumentoModel)
        {
            DocumentoModel documento = await _documento.Atualizar(DocumentoModel);
            return Ok(documento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentoModel>> Apagar(int id)
        {
            bool apagado = await _documento.Apagar(id);
            return Ok(apagado);
        }
    }
}
