using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;

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
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<IEnumerable<DocumentoVersaoDto>>> Get()
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarTodosTipoDocumentos();
            if (documentoVersaoDto == null) return NotFound("Tipos de Versão do Documento não encontrado!");
            return Ok(documentoVersaoDto);
        }

        [HttpGet("{id:int}", Name = "ObterVersaoDocumento")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoVersaoDto>> Get(int id)
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarPorId(id);
            if (documentoVersaoDto == null) return NotFound("Tipo de Versão do Documento não encontrado");
            return Ok(documentoVersaoDto);
        }

        [HttpPost]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Post([FromBody] DocumentoVersaoDto documentoVersaoDto)
        {
            if (documentoVersaoDto is null) return BadRequest("Dado inválido!");
            await _documentoVersaoService.Adicionar(documentoVersaoDto);
            return Ok("Versão do Documento registrado com sucesso");
        }

        [HttpPut("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Put([FromBody] DocumentoVersaoDto documentoVersaoDto)
        {
            if (documentoVersaoDto is null) return BadRequest("Dado invalido!");
            await _documentoVersaoService.Atualizar(documentoVersaoDto);
            return Ok(documentoVersaoDto);
        }

        [HttpDelete("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoVersaoDto>> Delete(int id)
        {
            var documentoVersaoDto = await _documentoVersaoService.BuscarPorId(id);
            if (documentoVersaoDto == null) return NotFound("Tipo de Versão do Documento não encontrado");
            await _documentoVersaoService.Apagar(id);
            return Ok(documentoVersaoDto);
        }
    }
}
