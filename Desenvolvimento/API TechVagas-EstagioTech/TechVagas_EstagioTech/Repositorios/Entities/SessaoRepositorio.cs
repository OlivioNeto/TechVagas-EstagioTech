using Microsoft.EntityFrameworkCore;
using System;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class SessaoRepositorio : ISessaoRepositorio
    {
        private readonly DBContext _dbContext;

        public SessaoRepositorio(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SessaoModel>> GetAll()
        {
            return await _dbContext.Sessao.ToListAsync();
        }

        public async Task<IEnumerable<IEnumerable<SessaoModel>>> GetAllSessionsGroupedByUser()
        {
            return await _dbContext.Sessao.GroupBy(sessao => sessao.UsuarioId).Select(group => group.OrderBy(sessao => sessao.UsuarioId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SessaoModel>> GetOpenSessions()
        {
            return await _dbContext.Sessao.Where(sessao => sessao.StatusSessao).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SessaoModel>> GetCloseSessions()
        {
            return await _dbContext.Sessao.Where(sessao => !sessao.StatusSessao).AsNoTracking().ToListAsync();
        }

        public async Task<SessaoModel> GetLastSession(int id)
        {
            return await _dbContext.Sessao.Where(sessao => sessao.UsuarioId == id).OrderByDescending(sessao => sessao.UsuarioId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<SessaoModel> GetById(int id)
        {
            // return await _dbContext.Sessao.Where(sessao => sessao.Id == id).Include(sessao => sessao.Usuario).ThenInclude(usuario => usuario.TipoUsuario).FirstOrDefaultAsync();
            return await _dbContext.Sessao.Where(sessao => sessao.UsuarioId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<SessaoModel> GetByToken(string token)
        {
            return await _dbContext.Sessao.Where(sessao => sessao.TokenSessao == token).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<UsuarioModel> GetUser(string token)
        {
            var sessao = await _dbContext.Sessao
                .Include(s => s.UsuarioModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.TokenSessao == token);

            return sessao?.UsuarioModel;
        }

        public async Task<SessaoModel> Create(SessaoModel sessaoModel)
        {
            _dbContext.Sessao.Add(sessaoModel);
            await _dbContext.SaveChangesAsync();
            return sessaoModel;
        }

        public async Task<SessaoModel> Update(SessaoModel sessaoModel)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(sessaoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return sessaoModel;
        }

        public async Task<SessaoModel> Delete(int id)
        {
            var sessao = await GetById(id);
            _dbContext.Sessao.Remove(sessao);
            await _dbContext.SaveChangesAsync();
            return sessao;
        }

        public async Task<IEnumerable<UsuarioModel>> GetOnlineUsers()
        {
            return await _dbContext.Usuario.GroupJoin(
                _dbContext.Sessao,
                usuario => usuario.UsuarioId,
                sessao => sessao.UsuarioId,
                (usuario, sessoes) => new { Usuario = usuario, UltimaSessao = sessoes.OrderByDescending(s => s.UsuarioId).FirstOrDefault() }
            ).Where(sessao => sessao.Usuario.UsuarioId != 1 && (sessao.UltimaSessao != null && sessao.UltimaSessao.StatusSessao)).AsNoTracking().Select(sessao => sessao.Usuario).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> GetOfflineUsers()
        {
            return await _dbContext.Usuario.GroupJoin(
                _dbContext.Sessao,
                usuario => usuario.UsuarioId,
                sessao => sessao.UsuarioId,
                (usuario, sessoes) => new { Usuario = usuario, UltimaSessao = sessoes.OrderByDescending(s => s.UsuarioId).FirstOrDefault() }
            ).Where(sessao => sessao.Usuario.UsuarioId != 1 && (sessao.UltimaSessao == null || !sessao.UltimaSessao.StatusSessao)).AsNoTracking().Select(sessao => sessao.Usuario).ToListAsync();
        }

        public async Task<IEnumerable<SessaoModel>> GetOpenSessionByUser(int id)
        {
            return await _dbContext.Sessao.Where(sessao => sessao.StatusSessao && sessao.UsuarioId == id).AsNoTracking().ToListAsync();
        }
    }
}
