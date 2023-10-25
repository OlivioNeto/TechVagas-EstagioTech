using Microsoft.AspNetCore.Http;
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
    }
}
