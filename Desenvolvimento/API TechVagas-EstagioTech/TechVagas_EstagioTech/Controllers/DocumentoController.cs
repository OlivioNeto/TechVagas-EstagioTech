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
        private readonly IUsuarioService _usuarioService;
        private readonly IAlunoService _alunoService;
        private readonly IMatriculaService _matriculaService;
        private readonly ICoordenadorEstagioService _coordenadorEstagioService;
        private readonly IContratoEstagioService _contratoEstagioService;
        private readonly IDocumentoVersaoService _documentoVersaoService;
        private readonly IDocumentoService _documentoService;
        private Response _response;

        public DocumentoController(IUsuarioService usuarioService, IAlunoService alunoService, IMatriculaService matriculaService, ICoordenadorEstagioService coordenadorEstagioService, IContratoEstagioService contratoEstagioService, IDocumentoVersaoService documentoVersaoService, IDocumentoService documentoService)
        {
            _usuarioService = usuarioService;
            _alunoService = alunoService;
            _matriculaService = matriculaService;
            _coordenadorEstagioService = coordenadorEstagioService;
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

        [HttpGet("ObterDocumentosRelacionadosContrato/{idUsuario:int}", Name = "ObterDocumentosRelacionadosContrato")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<dynamic>> ObterDocumentosRelacionadosContrato(int idUsuario)
        {
            if (idUsuario == 0)
            {
                return BadRequest("Informe o Id do Usuário");
            }

            var usuario = await _usuarioService.BuscarPorId(idUsuario);

            if (usuario is null)
            {
                return BadRequest("Usuário não encontrado");
            }

            var aluno = await _alunoService.BuscarPorEmail(usuario.Email);

            if (aluno is null)
            {
                return BadRequest("Aluno não encontrado");
            }

            dynamic dados = new ExpandoObject();

            // Obter a matrícula do aluno
            var matricula = await _matriculaService.BuscarPorAluno(aluno.AlunoId);
            if (matricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }

            dados.idMatricula = matricula.MatriculaId;
            dados.numeroMatricula = matricula.NumeroMatricula;
            dados.idAluno = matricula.AlunoId;
            dados.idCurso = matricula.cursoid;

            // Obter contratos relacionados à matrícula
            var contratos = await _contratoEstagioService.BuscarPorMatricula(matricula.MatriculaId);
            dados.contratos = new List<dynamic>();

            foreach (var contrato in contratos)
            {
                dynamic contratoDynamic = new ExpandoObject();
                contratoDynamic.idContratoEstagio = contrato.idContratoEstagio;
                contratoDynamic.statusContratoEstagio = contrato.statusContratoEstagio;
                contratoDynamic.notalFinal = contrato.notaFinal;
                contratoDynamic.situacao = contrato.situacao;
                contratoDynamic.horarioEntrada = contrato.horarioEntrada;
                contratoDynamic.horarioSaida = contrato.horarioSaida;
                contratoDynamic.dataInicio = contrato.dataInicio;
                contratoDynamic.dataFim = contrato.dataFim;
                contratoDynamic.salario = contrato.salario;
                contratoDynamic.cargaSemanal = contrato.cargaSemanal;
                contratoDynamic.cargaTotal = contrato.cargaTotal;
                contratoDynamic.idTipoEstagio = contrato.idTipoEstagio;
                contratoDynamic.idSupervisorEstagio = contrato.idSupervisorEstagio;
                contratoDynamic.idCoorderneadorEstagio = contrato.idCoordenadorEstagio;

                // Obter documentos relacionados ao contrato
                var coordenadorDados = await _coordenadorEstagioService.BuscarPorId(contrato.idCoordenadorEstagio);

                dynamic coordenador = new ExpandoObject();
                coordenador.idCoordenadorEstagio = coordenadorDados.idCoordenadorEstagio;
                coordenador.dataCadastro = coordenadorDados.dataCadastro;
                coordenador.nomeCoordenador = coordenadorDados.nomeCoordenador;
                coordenador.status = coordenadorDados.Status;

                contratoDynamic.coordenador = coordenador;

                // Obter documentos relacionados ao contrato
                var documentos = await _documentoService.BuscarPorContrato(contrato.idContratoEstagio);
                contratoDynamic.documentos = new List<dynamic>();

                foreach (var documento in documentos)
                {
                    dynamic documentoDynamic = new ExpandoObject();
                    documentoDynamic.idDocumento = documento.idDocumento;
                    documentoDynamic.situacaoDocumento = documento.descricaoDocumento;
                    documentoDynamic.status = documento.Status;
                    documentoDynamic.situacaoDocumento = documento.situacaoDocumento;
                    documentoDynamic.idCoordenadorEstagio = documento.idCoordenadorEstagio;
                    documentoDynamic.idTipoDocumento = documento.idTipoDocumento;

                    // Obter versões do documento
                    var documentoVersoes = await _documentoVersaoService.BuscarPorDocumento(documento.idDocumento);

                    if (documentoVersoes != null)
                    {
                        dynamic versaoDynamic = new ExpandoObject();
                        versaoDynamic.idDocumentoVersao = documentoVersoes.idDocumentoVersao;
                        versaoDynamic.comentario = documentoVersoes.Comentario;
                        versaoDynamic.anexo = documentoVersoes.Anexo;
                        versaoDynamic.data = documentoVersoes.Data;
                        versaoDynamic.situacao = documentoVersoes.Situacao;
                        versaoDynamic.idDocumento = documentoVersoes.idDocumento;

                        documentoDynamic.documentoVersao = versaoDynamic;
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
