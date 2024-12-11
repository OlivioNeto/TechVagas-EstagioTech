using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
		private readonly ITipoDocumentoService _tipoDocumentoService;
        private Response _response;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
		{
			_tipoDocumentoService = tipoDocumentoService;

            _response = new Response();
        }

		[HttpGet]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarTodosTipoDocumentos();
			if (tipoDocumentoDto == null) return NotFound("Tipos de Documentos não encontrados!");
			return Ok(tipoDocumentoDto);
		}

		[HttpGet("{id:int}", Name = "ObterTipoDocumento")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
			if (tipoDocumentoDto == null) return NotFound("Tipo de Documento não encontrado");
			return Ok(tipoDocumentoDto);
		}

		[HttpPost]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Post([FromBody] string descricaoTipoDocumento)
		{	
			if (string.IsNullOrEmpty(descricaoTipoDocumento)) return BadRequest("Dado inválido!");


			await _tipoDocumentoService.Adicionar(descricaoTipoDocumento);
			return Ok("Documento registrado com sucesso");
		}

		[HttpPut("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Put([FromBody] TipoDocumentoDto tipoDocumentoDto)
		{
			if (tipoDocumentoDto is null) return BadRequest("Dado invalido!");
			await _tipoDocumentoService.Atualizar(tipoDocumentoDto);
			return Ok(tipoDocumentoDto);
		}

        [HttpPut("{id}/Ativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<TipoDocumentoDto>> Activity(int id)
        {
            var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
            if (tipoDocumentoDto == null)
            {
                _response.Status = false;
                _response.Message = "Tipo Documento não encontrado!";
                _response.Data = tipoDocumentoDto;
                return NotFound(_response);
            }

            if (!tipoDocumentoDto.Status)
            {
                tipoDocumentoDto.Status = true; // Ativando o documento
                await _tipoDocumentoService.Atualizar(tipoDocumentoDto);
            }

            _response.Status = true;
            _response.Message = "Tipo Documento " + tipoDocumentoDto.descricaoTipoDocumento + " ativado com sucesso.";
            _response.Data = tipoDocumentoDto;
            return Ok(_response);
        }


        [HttpPut("{id}/Desativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<TipoDocumentoDto>> Desactivity(int id)
        {
            var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
            if (tipoDocumentoDto == null)
            {
                _response.Status = false; _response.Message = "Tipo Documento não encontrado!"; _response.Data = tipoDocumentoDto;
                return NotFound(_response);
            }

            if (tipoDocumentoDto.Status)
            {
                tipoDocumentoDto.DisableAllOperations();
                await _tipoDocumentoService.Atualizar(tipoDocumentoDto);
            }

            _response.Status = true; _response.Message = "Tipo Documento " + tipoDocumentoDto.descricaoTipoDocumento + " desativado com sucesso."; _response.Data = tipoDocumentoDto;
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<TipoDocumentoDto>> Delete(int id)
		{
			var tipoDocumentoDto = await _tipoDocumentoService.BuscarPorId(id);
			if (tipoDocumentoDto == null) return NotFound("Tipo de Documento não econtrado!");
			await _tipoDocumentoService.Apagar(id);
			return Ok(tipoDocumentoDto);
		}
	}
}
