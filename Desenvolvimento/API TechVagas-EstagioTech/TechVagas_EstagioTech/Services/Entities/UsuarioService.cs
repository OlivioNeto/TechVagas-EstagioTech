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

            /* IEnumerable<UsuarioDto> usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            foreach (var usuarioDTO in usuariosDto)
            {
                var usuario = usuarios.FirstOrDefault(u => u.UsuarioId == usuarioDTO.Id);
                if (usuario != null)
                {
                    Type tipoUsuarioDTO = _mapper.Map<Type>(usuario.Type);
                    usuarioDTO.Type = UserType;
                }
            }

            return usuariosDTO; */
        }

        public async Task<UsuarioDto> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);

            UsuarioDto usuarioDTO = _mapper.Map<UsuarioDto>(usuario);
           // usuarioDTO.Type = _mapper.Map<UserType>(usuario.Type);

            return usuarioDTO;
        }



        public async Task Apagar(int id)
        {
            await _usuarioRepositorio.Apagar(id);
        }

    }
}
