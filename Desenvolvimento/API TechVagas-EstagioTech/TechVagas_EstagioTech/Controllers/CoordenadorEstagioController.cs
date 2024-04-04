using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordenadorEstagioController : ControllerBase
    {
        private readonly ICoordenadorEstagioService _coordenadorEstagioService;

        public CoordenadorEstagioController(ICoordenadorEstagioService cordenadorEstagioService)
        {
            _coordenadorEstagioService = cordenadorEstagioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoordenadorEstagioDto>>> Get()
        {
            var cordenadorEstagioDto = await _coordenadorEstagioService.BuscarTodosCoordenadoresEstagio();
            if (cordenadorEstagioDto == null) return NotFound("Coordenadores não encontrados!");
            return Ok(cordenadorEstagioDto);
        }

        [HttpGet("{id:int}", Name = "ObterCoordenadorEstagio")]
        public async Task<ActionResult<CoordenadorEstagioDto>> Get(int id)
        {
            var cordenadorEstagioDto = await _coordenadorEstagioService.BuscarPorId(id);
            if (cordenadorEstagioDto == null) return NotFound("Coordenadores não encontrados!");
            return Ok(cordenadorEstagioDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CoordenadorEstagioDto coordenadorEstagioDto)
        {
            if (coordenadorEstagioDto is null) return BadRequest("Dado inválido!");
            await _coordenadorEstagioService.Adicionar(coordenadorEstagioDto);
            return Ok("Dado cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CoordenadorEstagioDto coordenadorEstagioDto)
        {
            if (coordenadorEstagioDto is null) return BadRequest("Dado invalido!");
            await _coordenadorEstagioService.Atualizar(coordenadorEstagioDto);
            return Ok(coordenadorEstagioDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CoordenadorEstagioDto>> Delete(int id)
        {
            var coordenadorEstagioDto = await _coordenadorEstagioService.BuscarPorId(id);
            if (coordenadorEstagioDto == null) return NotFound("Documento não econtrado!");
            await _coordenadorEstagioService.Apagar(id);
            return Ok(coordenadorEstagioDto);
        }
    }
}
