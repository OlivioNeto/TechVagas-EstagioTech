using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;
using TechVagas_EstagioTech.Objects.Model;
using System.Dynamic;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IMatriculaService _matriculaService;
        private readonly IContratoEstagioService _contratoEstagioService;
        private readonly IDocumentoVersaoService _documentoVersaoService;
        private readonly IDocumentoService _documentoService;
        private Response _response;

        public DocumentoController(IAlunoService alunoService, IMatriculaService matriculaService, IContratoEstagioService contratoEstagioService, IDocumentoVersaoService documentoVersaoService, IDocumentoService documentoService)
        {
            _alunoService = alunoService;
            _matriculaService = matriculaService;
            _contratoEstagioService = contratoEstagioService;
            _documentoVersaoService = documentoVersaoService;
            _documentoService = documentoService;

            _response = new Response();
        }

        [HttpGet]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<IEnumerable<DocumentoDto>>> Get()
        {
            var documentoDto = await _documentoService.BuscarTodosDocumentos();
            if (documentoDto == null) return NotFound("Documentos não encontrados!");
            return Ok(documentoDto);
        }

        [HttpGet("{id:int}", Name = "ObterDocumento")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Get(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null) return NotFound("Documento não encontrado");
            return Ok(documentoDto);
        }

        [HttpGet("{idAluno:int}", Name = "ObterDocumentosRelacionadosContrato")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<dynamic>> ObterDocumentosRelacionadosContrato(int idAluno)
        {
            if (idAluno == 0)
            {
                return BadRequest("Informe o Id do Aluno");
            }

            dynamic dados = new ExpandoObject();

            // Obter a matrícula do aluno
            var matricula = await _matriculaService.GetByAluno(idAluno);
            if (matricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }

            dados.idMatricula = matricula.MatriculaId;
            dados.numeroMatricula = matricula.NumeroMatricula;
            dados.idAluno = matricula.AlunoId;
            dados.idCurso = matricula.cursoId;

            // Obter contratos relacionados à matrícula
            var contratos = await _contratoEstagioService.GetByMatricula(matricula.MatriculaId);
            dados.contratos = new List<dynamic>();

            foreach (var contrato in contratos)
            {
                dynamic contratoDynamic = new ExpandoObject();
                contratoDynamic.idContratoEstagio = contrato.idContratoEstagio;
                contratoDynamic.statusContratoEstagio = contrato.statusContratoEstagio;
                contratoDynamic.notalFinal = contrato.notaFInal;
                contratoDynamic.situacao = contrato.situacao;
                contratoDynamic.horarioEntrada = contrato.horaEntrada;
                contratoDynamic.horarioSaida = contrato.horarioSaida;
                contratoDynamic.dataInicio = contrato.dataInicio;
                contratoDynamic.dataFim = contrato.dataFIm;
                contratoDynamic.salario = contrato.salario;
                contratoDynamic.cargaSemanal = contrato.cargaSemanal;
                contratoDynamic.cargaTotal = contrato.cargaTotal;
                contratoDynamic.idTipoEstagio = contrato.idTIpoEstagio;
                contratoDynamic.idSupervisorEstagio = contrato.idSupervisorEstagio;
                contratoDynamic.idCoorderneadorEstagio = contrato.idCoorderneadorEstagio;

                // Obter documentos relacionados ao contrato
                var documentos = await _documentoService.GetByContrato(contrato.IdContratoEstagio);
                contratoDynamic.documentos = new List<dynamic>();

                foreach (var documento in documentos)
                {
                    dynamic documentoDynamic = new ExpandoObject();
                    documentoDynamic.idDocumento = documento.IdDocumento;
                    documentoDynamic.situacaoDocumento = documento.descricaoDocumento;
                    documentoDynamic.status = documento.status;
                    documentoDynamic.idCoordenadorEstagio = documento.idCoordenadorEstagio;
                    documentoDynamic.idTipoDocumento = documento.idTipoDocumento;

                    // Obter versões do documento
                    var documentoVersoes = await _documentoVersaoService.GetByDocument(documento.IdDocumento);
                    documentoDynamic.documentoVersao = new List<dynamic>();

                    foreach (var versao in documentoVersoes)
                    {
                        dynamic versaoDynamic = new ExpandoObject();
                        versaoDynamic.idDocumentoVersao = versao.idDocumentoVersao;
                        versaoDynamic.comentario = versao.Comentario;
                        versaoDynamic.anexo = versao.Anexo;
                        versaoDynamic.data = versao.Data;
                        versaoDynamic.situacao = versao.Situacao;
                        versaoDynamic.idDocumento = versao.idDocumento;

                        documentoDynamic.documentoVersao.Add(versaoDynamic);
                    }

                    contratoDynamic.documentos.Add(documentoDynamic);
                }

                dados.contratos.Add(contratoDynamic);
            }

            return Ok(dados);
        }

        [HttpPost]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Post([FromBody] DocumentoDto documentoDto)
        {
            if (documentoDto is null) return BadRequest("Dado inválido!");
            await _documentoService.Adicionar(documentoDto);
            return Ok("Dado cadastrado com sucesso");
        }

        [HttpPut("{id}/Ativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Activity(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null)
            {
                _response.Status = false;
                _response.Message = "Tipo Documento não encontrado!";
                _response.Data = documentoDto;
                return NotFound(_response);
            }

            if (documentoDto.Status)
            {
                documentoDto.Status = true; // Ativando o documento
                await _documentoService.Atualizar(documentoDto);
            }

            _response.Status = true;
            _response.Message = "Documento " + documentoDto.situacaoDocumento + " ativado com sucesso.";
            _response.Data = documentoDto;
            return Ok(_response);
        }


        [HttpPut("{id}/Desativar")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Desactivity(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null)
            {
                _response.Status = false; _response.Message = "Documento não encontrado!"; _response.Data = documentoDto;
                return NotFound(_response);
            }

            if (documentoDto.Status)
            {
                documentoDto.DisableAllOperations();
                await _documentoService.Atualizar(documentoDto);
            }

            _response.Status = true; _response.Message = "Documento " + documentoDto.situacaoDocumento + " desativado com sucesso."; _response.Data = documentoDto;
            return Ok(_response);
        }

        [HttpPut("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Put([FromBody] DocumentoDto documentoDto)
        {
            if (documentoDto is null) return BadRequest("Dado invalido!");
            await _documentoService.Atualizar(documentoDto);
            return Ok(documentoDto);
        }

        [HttpDelete("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<DocumentoDto>> Delete(int id)
        {
            var documentoDto = await _documentoService.BuscarPorId(id);
            if (documentoDto == null) return NotFound("Documento não econtrado!");
            await _documentoService.Apagar(id);
            return Ok(documentoDto);
        }
    }
}
