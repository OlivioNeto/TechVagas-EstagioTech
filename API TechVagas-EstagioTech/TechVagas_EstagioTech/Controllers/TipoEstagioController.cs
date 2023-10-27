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
    public class TipoEstagioController : ControllerBase
    {
		private readonly ITipoEstagioService _tipoEstagioService;

		public TipoEstagioController(ITipoEstagioService tipoEstagioService)
		{
			_tipoEstagioService = tipoEstagioService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TipoEstagioDto>>> Get()
		{
			var tipoEstagioDto = await _tipoEstagioService.BuscarTodosTipoEstagio();
			if (tipoEstagioDto == null) return NotFound("Tipos de Estagio não encontrados!");
			return Ok(tipoEstagioDto);
		}

		[HttpGet("{id:int}", Name = "ObterTipoEstagio")]
		public async Task<ActionResult<TipoEstagioDto>> Get(int id)
		{
			var tipoEstagioDto = await _tipoEstagioService.BuscarPorId(id);
			if (tipoEstagioDto == null) return NotFound("Tipo de Estagio não encontrado");
			return Ok(tipoEstagioDto);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] TipoEstagioDto tipoEstagioDto)
		{
			if (tipoEstagioDto is null) return BadRequest("Dado inválido!");
			await _tipoEstagioService.Adicionar(tipoEstagioDto);
			return new CreatedAtRouteResult("GetTipoEstagio", new { id = tipoEstagioDto.idTipoEstagio }, tipoEstagioDto);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put([FromBody] TipoEstagioDto tipoEstagioDto)
		{
			if (tipoEstagioDto is null) return BadRequest("Dado invalido!");
			await _tipoEstagioService.Atualizar(tipoEstagioDto);
			return Ok(tipoEstagioDto);
		}

		[HttpDelete("{id}")]
        public async Task<ActionResult<TipoEstagioModel>> Apagar(int id)
        {
            bool apagado = await _tipoEstagioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
