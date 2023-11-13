using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoVersaoController : ControllerBase
    {
        private readonly IDocumentoVersaoService _documentoVersaoService;

        public DocumentoVersaoController(IDocumentoVersaoService documentoVersaoService)
        {
            _documentoVersaoService = documentoVersaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoVersaoDto>>> Get()
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarTodosTipoDocumentos();
            if (documentoVersaoDto == null) return NotFound("Tipos de Versão do Documento não encontrado!");
            return Ok(documentoVersaoDto);
        }

        [HttpGet("{id:int}", Name = "ObterVersaoDocumento")]
        public async Task<ActionResult<DocumentoVersaoDto>> Get(int id)
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarPorId(id);
            if (documentoVersaoDto == null) return NotFound("Tipo de Versão do Documento não encontrado");
            return Ok(documentoVersaoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string comentario)
        {
            if (comentario is null) return BadRequest("Dado inválido!");
            await _documentoVersaoService.Adicionar(comentario);
            return Ok("Versão do Documento registrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] DocumentoVersaoDto documentoVersaoDto)
        {
            if (documentoVersaoDto is null) return BadRequest("Dado invalido!");
            await _documentoVersaoService.Atualizar(documentoVersaoDto);
            return Ok(documentoVersaoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DocumentoVersaoDto>> Delete(int id)
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarPorId(id);
            if (documentoVersaoDto == null) return NotFound("Tipo de Versão do Documento não encontrado");
            await _documentoVersaoService.Apagar(id);
            return Ok(documentoVersaoDto);
        }
    }
}
