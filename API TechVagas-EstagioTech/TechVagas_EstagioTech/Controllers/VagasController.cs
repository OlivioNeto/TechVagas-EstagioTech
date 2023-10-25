﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly IVagasInteface _vagas;

        public VagasController(IVagasInteface vagas)
        {
            _vagas = vagas;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VagasDto>>> Get()
        {
            var vagasDto = await _vagas.BuscarTodasVagas();
            if (vagasDto == null) return NotFound("Vagas não encontradas!");
            return Ok(vagasDto);
        }

        [HttpGet("{id:int}", Name = "ObterVaga")]
        public async Task<ActionResult<VagasDto>> Get(int id)
        {
            var vagasDto = await _vagas.BuscarPorId(id);
            if (vagasDto == null) return NotFound("Cargo não encontrado");
            return Ok(vagasDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VagasDto vagasDto)
        {
            if (vagasDto is null) return BadRequest("Dado inválido!");
            await _vagas.Adicionar(vagasDto);
            return new CreatedAtRouteResult("GetCargo", new { id = vagasDto.VagasId }, vagasDto);
        }
    }
}
