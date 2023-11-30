using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> BuscarTodosUsuarios()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> BuscarPorEmail(string email)
        {
            var usuarios = await _usuarioRepositorio.BuscarPorEmail(email);
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> Login(LoginDto loginDto)
        {
            var login = _mapper.Map<LoginModel>(loginDto);
            var usuario = await _usuarioRepositorio.Login(login);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task Adicionar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            await _usuarioRepositorio.Adicionar(usuario);
            usuarioDto.usuarioId = usuario.usuarioId;
        }

        public async Task Atualizar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            await _usuarioRepositorio.Atualizar(usuario);
        }

        public async Task Apagar(int id)
        {
            await _usuarioRepositorio.Apagar(id);
        }
    }
}
