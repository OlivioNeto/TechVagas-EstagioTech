using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoInterface _documento;
        public DocumentoController(IDocumentoInterface documento)
        {
            _documento = documento;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentoModel>>> BuscarTodosDocumentos()
        {
            List<DocumentoModel> documento = await _documento.BuscarTodosDocumentos();
            return Ok(documento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DocumentoModel>>> BuscarPorId(int id)
        {
            DocumentoModel documento = await _documento.BuscarPorId(id);
            return Ok(documento);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoModel>> Cadastrar([FromBody] DocumentoModel DocumentoModel)
        {
            DocumentoModel documento = await _documento.Adicionar(DocumentoModel);
            return Ok(documento);
        }

        [HttpPut]
        public async Task<ActionResult<DocumentoModel>> Atualizar([FromBody] DocumentoModel DocumentoModel)
        {
            DocumentoModel documento = await _documento.Atualizar(DocumentoModel);
            return Ok(documento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentoModel>> Apagar(int id)
        {
            bool apagado = await _documento.Apagar(id);
            return Ok(apagado);
        }
    }
}
