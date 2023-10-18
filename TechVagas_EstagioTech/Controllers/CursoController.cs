using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepositorio _curso;
        public CursoController(ICursoRepositorio curso)
        {
            _curso = curso;
        }

        [HttpGet]

        public async Task<ActionResult<List<CursoModel>>> BuscarTodosTiposEstagio()
        {
            List<CursoModel> curso = await _curso.BuscarTodosTiposEstagios();
            return Ok(curso);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CursoModel>>> BuscarPorId(int id)
        {
            CursoModel curso = await _curso.BuscarPorId(id);
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<CursoModel>> Cadastrar([FromBody] CursoModel CursoModel)
        {
            CursoModel curso = await _curso.Adicionar(CursoModel);
            return Ok(curso);
        }


        [HttpPut]
        public async Task<ActionResult<CursoModel>> Atualizar([FromBody] CursoModel CursoModel)
        {
            CursoModel tipoEstagio = await _curso.Atualizar(CursoModel);
            return Ok(tipoEstagio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CursoModel>> Apagar(int id)
        {
            bool apagado = await _curso.Apagar(id);
            return Ok(apagado);
        }
    }
}
