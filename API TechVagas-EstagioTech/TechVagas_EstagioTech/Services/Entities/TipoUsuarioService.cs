using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepositorio _tipoUsuarioRepositorio;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ITipoUsuarioRepositorio tipoUsuarioRepositorio, IMapper mapper)
        {
            _tipoUsuarioRepositorio = tipoUsuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoUsuarioDto>> BuscarTodosTipoUsuario()
        {
            var tipoUsuario = await _tipoUsuarioRepositorio.BuscarTodosTipoUsuario();
            return _mapper.Map<IEnumerable<TipoUsuarioDto>>(tipoUsuario);
        }

        public async Task<TipoUsuarioDto> BuscarPorId(int id)
        {
            var tipoUsuario = await _tipoUsuarioRepositorio.BuscarPorId(id);
            return _mapper.Map<TipoUsuarioDto>(tipoUsuario);
        }

        public async Task Adicionar(TipoUsuarioDto tipoUsuarioDto)
        {
            var tipoUsuario = _mapper.Map<TipoUsuarioModel>(tipoUsuarioDto);
            await _tipoUsuarioRepositorio.Adicionar(tipoUsuario);
            tipoUsuarioDto.tipoUsuarioId = tipoUsuario.tipoUsuarioId;
        }

        public async Task Atualizar(TipoUsuarioDto tipoUsuarioDto)
        {
            var tipoUsuario = _mapper.Map<TipoUsuarioModel>(tipoUsuarioDto);
            await _tipoUsuarioRepositorio.Atualizar(tipoUsuario);
        }

        public async Task Apagar(int id)
        {
            await _tipoUsuarioRepositorio.Apagar(id);
        }
    }
}
