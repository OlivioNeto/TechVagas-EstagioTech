using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Objects.Enums;
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
            IEnumerable<UsuarioDto> usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            foreach (var usuarioDTO in usuariosDto)
            {
                var usuario = usuarios.FirstOrDefault(u => u.UsuarioId == usuarioDTO.UsuarioId);
                if (usuario != null)
                {
                    UserType UserType = _mapper.Map<UserType>(usuario.UserType);
                    usuarioDTO.UserType = UserType;
                }
            }

            return usuariosDto;
        }

        public async Task<UsuarioDto> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);

            UsuarioDto usuarioDTO = _mapper.Map<UsuarioDto>(usuario);
            usuarioDTO.UserType = _mapper.Map<UserType>(usuario.UserType);

            return usuarioDTO;
        }

        public async Task<UsuarioDto> Login(LoginDto loginDto)
        {
            var login = _mapper.Map<LoginModel>(loginDto);
            var usuario = await _usuarioRepositorio.Login(login);

            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            if (usuarioDto != null) { usuarioDto.UserType = _mapper.Map<UserType>(usuario.UserType); }

            return usuarioDto;
        }

        public async Task Adicionar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            await _usuarioRepositorio.Adicionar(usuario);
            usuarioDto.UsuarioId = usuario.UsuarioId;
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
