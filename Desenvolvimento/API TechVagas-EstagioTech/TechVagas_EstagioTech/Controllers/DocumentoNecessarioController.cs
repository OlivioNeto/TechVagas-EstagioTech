using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoNecessarioController : ControllerBase
    {
        private readonly IDocumentoNecessarioService _documentoNecessarioService;

        public DocumentoNecessarioController(IDocumentoNecessarioService documentoNecessarioService)
        {
            _documentoNecessarioService = documentoNecessarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoNecessarioDto>>> Get()
        {
            var documentoNecessarioDto = await _documentoNecessarioService.BuscarTodosDocumentosNecessarios();
            if (documentoNecessarioDto == null) return NotFound("Tipos de Documentos necessários!");
            return Ok(documentoNecessarioDto);
        }

        [HttpGet("{id:int}", Name = "ObterDocumentoNecessario")]
        public async Task<ActionResult<DocumentoNecessarioDto>> Get(int id)
        {
            var documentoNecessarioDto = await _documentoNecessarioService.BuscarPorId(id);
            if (documentoNecessarioDto == null) return NotFound("Tipo de Documento necessário não encontrado");
            return Ok(documentoNecessarioDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentoNecessarioDto documentoNecessarioDto)
        {
            if (documentoNecessarioDto is null) return BadRequest("Dado inválido!");
            await _documentoNecessarioService.Adicionar(documentoNecessarioDto);
            return Ok("Documento necessário registrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] DocumentoNecessarioDto documentoNecessarioDto)
        {
            if (documentoNecessarioDto is null) return BadRequest("Dado invalido!");
            await _documentoNecessarioService.Atualizar(documentoNecessarioDto);
            return Ok(documentoNecessarioDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DocumentoNecessarioDto>> Delete(int id)
        {
            var documentoNecessarioDto = await _documentoNecessarioService.BuscarPorId(id);
            if (documentoNecessarioDto == null) return NotFound("Documento necessário não encontrado");
            await _documentoNecessarioService.Apagar(id);
            return Ok(documentoNecessarioDto);
        }
    }
}
