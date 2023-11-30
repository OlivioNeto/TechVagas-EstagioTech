using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio
    {
        private readonly AppDbContext _dbContext;

        public TipoUsuarioRepositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TipoUsuarioModel>> BuscarTodosTipoUsuario()
        {
            return await _dbContext.tipoUsuario.Where(p => p.NomeTipoUsuario != "Desenvolvedor").ToListAsync();
        }

        public async Task<TipoUsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.tipoUsuario.Where(p => p.tipoUsuarioId == id).FirstOrDefaultAsync();
        }

        public async Task<TipoUsuarioModel> Adicionar(TipoUsuarioModel tipoUsuarioModel)
        {
            _dbContext.tipoUsuario.Add(tipoUsuarioModel);
            await _dbContext.SaveChangesAsync();
            return tipoUsuarioModel;
        }

        public async Task<TipoUsuarioModel> Atualizar(TipoUsuarioModel tipoUsuarioModel)
        {
            _dbContext.Entry(tipoUsuarioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tipoUsuarioModel;
        }

        public async Task<TipoUsuarioModel> Apagar(int id)
        {
            var tipoUsuario = await BuscarPorId(id);
            _dbContext.tipoUsuario.Remove(tipoUsuario);
            await _dbContext.SaveChangesAsync();
            return tipoUsuario;
        }
    }
}
