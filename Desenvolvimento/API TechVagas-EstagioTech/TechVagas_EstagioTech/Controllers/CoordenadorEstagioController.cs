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
    public class CoordenadorEstagioController : ControllerBase
    {
        private readonly ICoordenadorEstagioService _coordenadorEstagioService;
        private Response _response;

        public CoordenadorEstagioController(ICoordenadorEstagioService cordenadorEstagioService)
        {
            _coordenadorEstagioService = cordenadorEstagioService;
            _response = new Response();
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
            return Ok("Coordenador cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CoordenadorEstagioDto coordenadorEstagioDto)
        {
            if (coordenadorEstagioDto is null) return BadRequest("Dado invalido!");
            await _coordenadorEstagioService.Atualizar(coordenadorEstagioDto);
            return Ok(coordenadorEstagioDto);
        }

        [HttpPut("{id}/Ativar")]
        public async Task<ActionResult<CoordenadorEstagioDto>> Activity(int id)
        {
            var coordenadorEstagioDto = await _coordenadorEstagioService.BuscarPorId(id);
            if (coordenadorEstagioDto == null)
            {
                _response.Status = false;
                _response.Message = "Tipo Documento não encontrado!";
                _response.Data = coordenadorEstagioDto;
                return NotFound(_response);
            }

            if (!coordenadorEstagioDto.Status)
            {
                coordenadorEstagioDto.Status = true; // Ativando o documento
                await _coordenadorEstagioService.Atualizar(coordenadorEstagioDto);
            }

            _response.Status = true;
            _response.Message = "Coordenador de Estagio " + coordenadorEstagioDto.nomeCoordenador + " ativado com sucesso.";
            _response.Data = coordenadorEstagioDto;
            return Ok(_response);
        }


        [HttpPut("{id}/Desativar")]
        public async Task<ActionResult<CoordenadorEstagioDto>> Desactivity(int id)
        {
            var coordenadorEstagioDto = await _coordenadorEstagioService.BuscarPorId(id);
            if (coordenadorEstagioDto == null)
            {
                _response.Status = false; _response.Message = "Coordenador de Estagio não encontrado!"; _response.Data = coordenadorEstagioDto;
                return NotFound(_response);
            }

            if (coordenadorEstagioDto.Status)
            {
                coordenadorEstagioDto.DisableAllOperations();
                await _coordenadorEstagioService.Atualizar(coordenadorEstagioDto);
            }
            _response.Status = true; _response.Message = "Coordenador de Estagio " + coordenadorEstagioDto.nomeCoordenador + " desativado com sucesso."; _response.Data = coordenadorEstagioDto;
            return Ok(_response);
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
