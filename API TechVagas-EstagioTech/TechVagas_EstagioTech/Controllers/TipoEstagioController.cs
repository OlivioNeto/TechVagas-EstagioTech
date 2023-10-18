using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Model;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEstagioController : ControllerBase
    {
        private readonly ITipoEstagioRepositorio _tipoEstagioRepositorio;
        public TipoEstagioController(ITipoEstagioRepositorio tipoEstagioRepositorio)
        {
            _tipoEstagioRepositorio = tipoEstagioRepositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<TipoEstagioModel>>> BuscarTodosTiposEstagio()
        {
            List<TipoEstagioModel> tipoEstagios = await _tipoEstagioRepositorio.BuscarTodosTiposEstagios();
            return Ok(tipoEstagios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TipoEstagioModel>>> BuscarPorId(int id)
        {
            TipoEstagioModel tipoEstagios = await _tipoEstagioRepositorio.BuscarPorId(id);
            return Ok(tipoEstagios);
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
