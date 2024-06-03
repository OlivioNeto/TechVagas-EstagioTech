using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorEstagioController : ControllerBase
    {
        private readonly ISupervisorEstagioService _supervisorEstagioService;
        private SupervisorEstagioDto statusSupervisor;

        public SupervisorEstagioController(ISupervisorEstagioService supervisorEstagioService)
        {
            _supervisorEstagioService = supervisorEstagioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupervisorEstagioDto>>> Get()
        {
            var supervisorEstagioDto = await _supervisorEstagioService.BuscarTodosSupervisorEstagio();
            if (supervisorEstagioDto == null) return NotFound("Supervisor de Estagio não encontrado!");
            return Ok(supervisorEstagioDto);
        }

        [HttpGet("{id:int}", Name = "ObterSupervisorEstagio")]
        public async Task<ActionResult<SupervisorEstagioDto>> Get(int id)
        {
            var supervisorEstagioDto = await _supervisorEstagioService.BuscarPorId(id);
            if (supervisorEstagioDto == null) return NotFound("Supervisor de Estagio não encontrado");
            return Ok(supervisorEstagioDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SupervisorEstagioDto supervisorEstagioDto)
        {
            if (supervisorEstagioDto == null)
            {
                return BadRequest("Status do supervisor não pode ser nulo.");
            }

            await _supervisorEstagioService.Adicionar(supervisorEstagioDto.statusSupervisor);
            return Ok("Supervisor registrado com sucesso");
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] SupervisorEstagioDto supervisorEstagioDto)
        {
            if (supervisorEstagioDto is null) return BadRequest("Dado invalido!");
            await _supervisorEstagioService.Atualizar(supervisorEstagioDto);
            return Ok(supervisorEstagioDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SupervisorEstagioDto>> Delete(int id)
        {
            var supervisorEstagioDto = await _supervisorEstagioService.BuscarPorId(id);
            if (supervisorEstagioDto == null) return NotFound("Supervisor não econtrado!");
            await _supervisorEstagioService.Apagar(id);
            return Ok(supervisorEstagioDto);
        }
    }
}
