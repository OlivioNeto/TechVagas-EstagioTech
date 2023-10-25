using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoRepositorio _tipoDocumentoRepositorio;
        public TipoDocumentoController(ITipoDocumentoRepositorio tipoDocumentoRepositorio)
        {
            _tipoDocumentoRepositorio = tipoDocumentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentoModel>>> BuscarTodosDocumentos()
        {
            List<TipoDocumentoModel> tipoDocumentos = await _tipoDocumentoRepositorio.BuscarTodosTiposDocumentos();
            return Ok(tipoDocumentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TipoDocumentoModel>>> BuscarPorId(int id)
        {
            TipoDocumentoModel tipoDocumentos = await _tipoDocumentoRepositorio.BuscarPorId(id);
            return Ok(tipoDocumentos);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDocumentoModel>> Cadastrar([FromBody] TipoDocumentoModel tipoDocumentoModel)
        {
            TipoDocumentoModel tipoDocumento = await _tipoDocumentoRepositorio.Adicionar(tipoDocumentoModel);
            return Ok(tipoDocumento);
        }

        [HttpPut]
        public async Task<ActionResult<TipoDocumentoModel>> Atualizar([FromBody] TipoDocumentoModel tipoDocumentoModel)
        {
            TipoDocumentoModel tipoDocumento = await _tipoDocumentoRepositorio.Atualizar(tipoDocumentoModel);
            return Ok(tipoDocumento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDocumentoModel>> Apagar(int id)
        {
            bool apagado = await _tipoDocumentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
