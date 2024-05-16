using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly IVagasService _vagasService;

        public VagasController(IVagasService vagasService)
        {
			_vagasService = vagasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VagasDto>>> Get()
        {
            var vagasDto = await _vagasService.BuscarTodasVagas();
            if (vagasDto == null) return NotFound("Vagas não encontradas!");
            return Ok(vagasDto);
        }

        [HttpGet("{id:int}", Name = "ObterVaga")]
        public async Task<ActionResult<VagasDto>> Get(int id)
        {
            var vagasDto = await _vagasService.BuscarPorId(id);
            if (vagasDto == null) return NotFound("Vaga não encontrada");
            return Ok(vagasDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VagasDto vagasDto)
        {
            if (vagasDto is null) return BadRequest("Dado inválido!");
            await _vagasService.Adicionar(vagasDto);
            return new CreatedAtRouteResult("ObterVaga", new { id = vagasDto.VagasId }, vagasDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] VagasDto vagasDto)
        {
            if (vagasDto is null) return BadRequest("Dado invalido!");
            await _vagasService.Atualizar(vagasDto);
            return Ok(vagasDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VagasDto>> Delete(int id)
        {
            var vagasDto = await _vagasService.BuscarPorId(id);
            if (vagasDto == null) return NotFound("Vagas não econtradas!");
            await _vagasService.Apagar(id);
            return Ok(vagasDto);
        }
    }
}
