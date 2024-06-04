using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Objects.Model;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorEstagioController : ControllerBase
    {
        private readonly ISupervisorEstagioService _supervisorEstagioService;
        private Response _response;

        public SupervisorEstagioController(ISupervisorEstagioService supervisorEstagioService)
        {
            _supervisorEstagioService = supervisorEstagioService;

            _response = new Response();
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
            if (supervisorEstagioDto is null) return BadRequest("Dado inválido!");
            await  _supervisorEstagioService.Adicionar(supervisorEstagioDto);
            return Ok("Supervisor registrado com sucesso");
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] SupervisorEstagioDto supervisorEstagioDto)
        {
            if (supervisorEstagioDto is null) return BadRequest("Dado invalido!");
            await _supervisorEstagioService.Atualizar(supervisorEstagioDto);
            return Ok(supervisorEstagioDto);
        }

        [HttpPut("{id}/Ativar")]
        public async Task<ActionResult<SupervisorEstagioDto>> Activity(int id)
        {
            var supervisorEstagioDto = await _supervisorEstagioService.BuscarPorId(id);
            if (supervisorEstagioDto == null)
            {
                _response.Status = false;
                _response.Message = "Supervisor Estágio não encontrado!";
                _response.Data = supervisorEstagioDto;
                return NotFound(_response);
            }

            if (!supervisorEstagioDto.Status)
            {
                supervisorEstagioDto.Status = true; // Ativando o documento
                await _supervisorEstagioService.Atualizar(supervisorEstagioDto);
            }

            _response.Status = true;
            _response.Message = "Supervisor de Estágio " + supervisorEstagioDto.nomeSupervisor + " ativado com sucesso.";
            _response.Data = supervisorEstagioDto;
            return Ok(_response);
        }


        [HttpPut("{id}/Desativar")]
        public async Task<ActionResult<SupervisorEstagioDto>> Desactivity(int id)
        {
            var supervisorEstagioDto = await _supervisorEstagioService.BuscarPorId(id);
            if (supervisorEstagioDto == null)
            {
                _response.Status = false; _response.Message = "Supervisor de Estágio não encontrado!"; _response.Data = supervisorEstagioDto;
                return NotFound(_response);
            }

            if (supervisorEstagioDto.Status)
            {
                supervisorEstagioDto.DisableAllOperations();
                await _supervisorEstagioService.Atualizar(supervisorEstagioDto);
            }

            _response.Status = true; _response.Message = "Tipo Documento " + supervisorEstagioDto.nomeSupervisor + " desativado com sucesso."; _response.Data = supervisorEstagioDto;
            return Ok(_response);
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
