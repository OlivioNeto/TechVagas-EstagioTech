using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class SessaoService : ISessaoService
    {
        private readonly ISessaoRepositorio _sessaoRepositorio;
        private readonly IMapper _mapper;

        public SessaoService(ISessaoRepositorio sessaoRepositorio, IMapper mapper)
        {
            _sessaoRepositorio = sessaoRepositorio;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SessaoDto>> GetAll()
        {
            var sessoes = await _sessaoRepositorio.GetAll();
            return _mapper.Map<IEnumerable<SessaoDto>>(sessoes);
        }

        public async Task<IEnumerable<SessaoDto>> GetOpenSessions()
        {
            var sessoes = await _sessaoRepositorio.GetOpenSessions();
            return _mapper.Map<IEnumerable<SessaoDto>>(sessoes);
        }

        public async Task<IEnumerable<SessaoDto>> GetCloseSessions()
        {
            var sessoes = await _sessaoRepositorio.GetCloseSessions();
            return _mapper.Map<IEnumerable<SessaoDto>>(sessoes);
        }

        public async Task<SessaoDto> GetLastSession(int id)
        {
            var sessao = await _sessaoRepositorio.GetLastSession(id);
            return _mapper.Map<SessaoDto>(sessao);
        }

        public async Task<SessaoDto> GetByToken(string token)
        {
            var sessao = await _sessaoRepositorio.GetByToken(token);
            return _mapper.Map<SessaoDto>(sessao);
        }

        public async Task<SessaoDto> GetUser(string token)
        {
            var usuario = await _sessaoRepositorio.GetUser(token);
            return _mapper.Map<SessaoDto>(usuario);
        }

        public async Task Create(SessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<SessaoModel>(sessaoDto);
            await _sessaoRepositorio.Create(sessao);
            sessaoDto.SessaoId = sessao.SessaoId;
        }


        public async Task Update(SessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<SessaoModel>(sessaoDto);
            await _sessaoRepositorio.Update(sessao);
        }

        public async Task Remove(int id)
        {
            await _sessaoRepositorio.Delete(id);
        }


        public async Task<IEnumerable<UsuarioDto>> GetOnlineUsers()
        {
            var usuarios = await _sessaoRepositorio.GetOnlineUsers();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<IEnumerable<UsuarioDto>> GetOfflineUsers()
        {
            var usuarios = await _sessaoRepositorio.GetOfflineUsers();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<IEnumerable<SessaoDto>> GetOpenSessionByUser(int id)
        {
            var sessoes = await _sessaoRepositorio.GetOpenSessionByUser(id);
            return _mapper.Map<IEnumerable<SessaoDto>>(sessoes);
        }
    }
}
