using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class SupervisorEstagioRepositorio : ISupervisorEstagioRepositorio
    {
        private readonly DBContext _dbContext;

        public SupervisorEstagioRepositorio(DBContext supervisorEstagioDBContex)
        {
            _dbContext = supervisorEstagioDBContex;
        }

        public async Task<SupervisorEstagioModel> BuscarPorId(int id)
        {
            return await _dbContext.SupervisorEstagio.Where(x => x.idSupervisor == id).FirstOrDefaultAsync();
        }

        public async Task<List<SupervisorEstagioModel>> BuscarTodosSupervisorEstagio()
        {
            return await _dbContext.SupervisorEstagio.ToListAsync();
        }
        public async Task<SupervisorEstagioModel> Adicionar(SupervisorEstagioModel supervisorEstagioModel)
        {
            _dbContext.SupervisorEstagio.Add(supervisorEstagioModel);
            await _dbContext.SaveChangesAsync();
            return supervisorEstagioModel;
        }

        public async Task<SupervisorEstagioModel> Atualizar(SupervisorEstagioModel supervisorEstagioModel)
        {
            _dbContext.Entry(supervisorEstagioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return supervisorEstagioModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var supervisor = await BuscarPorId(id);
            _dbContext.SupervisorEstagio.Remove(supervisor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
