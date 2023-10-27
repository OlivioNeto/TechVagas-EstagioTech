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
        public async Task<ActionResult<TipoEstagioModel>> Cadastrar([FromBody] TipoEstagioModel tipoEstagioModel)
        {
            TipoEstagioModel tipoEstagio = await _tipoEstagioRepositorio.Adicionar(tipoEstagioModel);
            return Ok(tipoEstagio);
        }

        [HttpPut]
        public async Task<ActionResult<TipoEstagioModel>> Atualizar([FromBody] TipoEstagioModel tipoEstagioModel)
        {
            TipoEstagioModel tipoEstagio = await _tipoEstagioRepositorio.Atualizar(tipoEstagioModel);

            return Ok(tipoEstagio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEstagioModel>> Apagar(int id)
        {
            bool apagado = await _tipoEstagioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
