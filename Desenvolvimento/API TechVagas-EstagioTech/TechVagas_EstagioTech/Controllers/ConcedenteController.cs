using Microsoft.AspNetCore.Authorization;
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
    public class ConcedenteController : ControllerBase
    {
        private readonly IConcedenteService _concedenteService;
        private readonly ISupervisorEstagioService _supervisorEstagioService;
        private Response _response;

        public ConcedenteController(IConcedenteService concedenteService, ISupervisorEstagioService supervisorEstagioService)
        {
            _concedenteService = concedenteService;
            _supervisorEstagioService = supervisorEstagioService;
            _response = new Response();
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ConcedenteDto>>> Get()
        {
            var concedenteDto = await _concedenteService.BuscarTodosConcedentes();
            if (concedenteDto == null) return NotFound("Concedentes não encontradas!");
            return Ok(concedenteDto);
        }

        [HttpGet("{id:int}", Name = "ObterConcedente")]
        public async Task<ActionResult<ConcedenteDto>> Get(int id)
        {
            var concedenteDto = await _concedenteService.BuscarPorId(id);
            if (concedenteDto == null) return NotFound("Concedente não encontrado");
            return Ok(concedenteDto);

        }

        
        [HttpPost]
        [Authorize(Policy = "AdministradorPolicy")]
        public async Task<ActionResult> Post([FromBody] ConcedenteDto concedenteDto)
        {
            if (concedenteDto is null) return BadRequest("Dado inválido!");
            await _concedenteService.Adicionar(concedenteDto);
            return new CreatedAtRouteResult("ObterConcedente", new { id = concedenteDto.concedenteId }, concedenteDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] ConcedenteDto concedenteDto)
        {
            //if (concedentedto == null)
            //{
            //    _response.status = false;
            //    _response.message = "dado inválido!";
            //    _response.data = concedentedto;
            //    return badrequest(_response);
            //}

            //var existingconcedente = await _concedenteservice.buscarporid(concedentedto.concedenteid);
            //if (existingconcedente == null)
            //{
            //    _response.status = false;
            //    _response.message = "não existe o concedente informado!";
            //    _response.data = concedentedto;
            //    return badrequest(_response);
            //}
            //else if (!existingconcedente.status)
            //{
            //    _response.status = false;
            //    _response.message = "o concedente " + existingconcedente.concedenteid + " está desabilitado para alteração!";
            //    _response.data = concedentedto;
            //    return badrequest(_response);
            //}

                //var supervisorEstagioDto = await _supervisorEstagioService.BuscarPorId(concedenteDto.concedenteId);

                //if (tipoDocumentoDto == null)
                //{
                //    _response.Status = false;
                //    _response.Message = "O Tipo Documento não existe!";
                //    _response.Data = documentoNecessarioDto;
                //    return BadRequest(_response);
                //}
                //else if (!tipoDocumentoDto.Status)
                //{
                //    _response.Status = false;
                //    _response.Message = "O Tipo Documento " + tipoDocumentoDto.descricaoTipoDocumento + " está desabilitado para adicionar novos documentos necessarios!";
                //    _response.Data = documentoNecessarioDto;
                //    return BadRequest(_response);
                //}

                if (concedenteDto is null) return BadRequest("Dado invalido!");
            await _concedenteService.Atualizar(concedenteDto);
            return Ok(concedenteDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ConcedenteDto>> Delete(int id)
        {
            var concedenteDto = await _concedenteService.BuscarPorId(id);
            if (concedenteDto == null) return NotFound("Concedente não econtrada!");
            await _concedenteService.Apagar(id);
            return Ok(concedenteDto);
        }
    }
}
