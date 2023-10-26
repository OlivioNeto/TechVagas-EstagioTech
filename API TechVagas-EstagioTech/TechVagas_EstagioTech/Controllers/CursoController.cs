using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
		private readonly ICursoService _cursoService;

		public CursoController(ICursoService cursoService)
		{
			_cursoService = cursoService;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<CursoDto>>> Get()
		{
			var cursoDto = await _cursoService.BuscarTodosCursos();
			if (cursoDto == null) return NotFound("Cursos não encontradas!");
			return Ok(cursoDto);
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
