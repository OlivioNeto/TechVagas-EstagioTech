using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;
using TechVagas_EstagioTech.Objects.Model;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
		private readonly IDocumentoService _documentoService;
        private Response _response;

        public DocumentoController(IDocumentoService documentoService)
		{
			_documentoService = documentoService;

            _response = new Response();
        }

		[HttpGet]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<IEnumerable<DocumentoDto>>> Get()
		{
			var documentoDto = await _documentoService.BuscarTodosDocumentos();
			if (documentoDto == null) return NotFound("Documentos não encontrados!");
			return Ok(documentoDto);
		}

		[HttpGet("{id:int}", Name = "ObterDocumento")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Get(int id)
		{
			var documentoDto = await _documentoService.BuscarPorId(id);
			if (documentoDto == null) return NotFound("Documento não encontrado");
			return Ok(documentoDto);
		}


		[HttpPost]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Post([FromBody] DocumentoDto documentoDto)
        {
            if (documentoDto is null) return BadRequest("Dado inválido!");
            await _documentoService.Adicionar(documentoDto);
            return Ok("Dado cadastrado com sucesso");
        }

        [HttpPut("{id}/Ativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Activity(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null)
            {
                _response.Status = false;
                _response.Message = "Tipo Documento não encontrado!";
                _response.Data = documentoDto;
                return NotFound(_response);
            }

            if (documentoDto.Status)
            {
                documentoDto.Status = true; // Ativando o documento
                await _documentoService.Atualizar(documentoDto);
            }

            _response.Status = true;
            _response.Message = "Documento " + documentoDto.situacaoDocumento + " ativado com sucesso.";
            _response.Data = documentoDto;
            return Ok(_response);
        }


        [HttpPut("{id}/Desativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Desactivity(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null)
            {
                _response.Status = false; _response.Message = "Documento não encontrado!"; _response.Data = documentoDto;
                return NotFound(_response);
            }

            if (documentoDto.Status)
            {
                documentoDto.DisableAllOperations();
                await _documentoService.Atualizar(documentoDto);
            }

            _response.Status = true; _response.Message = "Documento " + documentoDto.situacaoDocumento + " desativado com sucesso."; _response.Data = documentoDto;
            return Ok(_response);
        }

        [HttpPut]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Put( [FromBody] DocumentoDto documentoDto)
		{
			if (documentoDto is null ) return BadRequest("Dado invalido!");
			await _documentoService.Atualizar(documentoDto);
			return Ok(documentoDto);
		}

		[HttpDelete("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Delete(int id)
		{
			var documentoDto = await _documentoService.BuscarPorId(id);
			if (documentoDto == null) return NotFound("Documento não econtrado!");
			await _documentoService.Apagar(id);
			return Ok(documentoDto);
		}
	}
}
