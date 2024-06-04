using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoNecessarioController : ControllerBase
    {
        private readonly IDocumentoNecessarioService _documentoNecessarioService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private Response _response;

        public DocumentoNecessarioController(IDocumentoNecessarioService documentoNecessarioService, ITipoDocumentoService tipoDocumentoService)
        {
            _documentoNecessarioService = documentoNecessarioService;
            _tipoDocumentoService = tipoDocumentoService;
            _response = new Response();
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

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] DocumentoNecessarioDto documentoNecessarioDto)
        {
            if (documentoNecessarioDto == null)
            {
                _response.Status = false;
                _response.Message = "Dado Inválido!"; 
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }

            var existingDocumentoNecessario = await _documentoNecessarioService.BuscarPorId(documentoNecessarioDto.idDocumentoNecessario);
            if (existingDocumentoNecessario == null)
            {
                _response.Status = false; 
                _response.Message = "Não existe o Documento Necessário informado!"; 
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }
            else if (!existingDocumentoNecessario.Status)
            {
                _response.Status = false;
                _response.Message = "O Documento Necessário " + existingDocumentoNecessario.idDocumentoNecessario + " está desabilitado para alteração!"; 
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }

            var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(documentoNecessarioDto.idTipoDocumento);

            if (tipoDocumentoDto == null)
            {
                _response.Status = false;
                _response.Message = "O Tipo Documento não existe!";
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }
            else if (!tipoDocumentoDto.Status)
            {
                _response.Status = false; 
                _response.Message = "O Tipo Documento " + tipoDocumentoDto.descricaoTipoDocumento + " está desabilitado para adicionar novos documentos necessarios!"; 
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }

            var documentosRelacionados = await _documentoNecessarioService.BuscarPorId(tipoDocumentoDto.idTipoDocumento);
            if (documentosRelacionados != null)
            {
                _response.Status = false;
                _response.Message = "Já existe o Documento Necessario " + documentoNecessarioDto.idDocumentoNecessario + " no Tipo Documento " + tipoDocumentoDto.descricaoTipoDocumento + "!";
                _response.Data = documentoNecessarioDto;
                return BadRequest(_response);
            }

            await _documentoNecessarioService.Atualizar(existingDocumentoNecessario);

            _response.Status = true;
            _response.Message = "Documento Necessario " + documentoNecessarioDto.idDocumentoNecessario + " alterado com sucesso.";
            _response.Data = existingDocumentoNecessario;
            return Ok(_response);
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
