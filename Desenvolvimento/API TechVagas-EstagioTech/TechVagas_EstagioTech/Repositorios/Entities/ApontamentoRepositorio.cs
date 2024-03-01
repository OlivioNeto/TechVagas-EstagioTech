using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class ApontamentoRepositorio : IApontamentoRepositorio
    {
        private readonly DBContext _dbContext;
        public ApontamentoRepositorio(DBContext apontamentoDBContext)
        {
            _dbContext = apontamentoDBContext;
        }

        public async Task<ApontamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Apontamento.Where(x => x.idApontamento == id).FirstOrDefaultAsync();
        }

        public async Task<List<ApontamentoModel>> BuscarApontamento()
        {
            return await _dbContext.Apontamento.ToListAsync();
        }

        public async Task<ApontamentoModel> Adicionar(ApontamentoModel apontamentoModel)
        {
            _dbContext.Apontamento.Add(apontamentoModel);
            await _dbContext.SaveChangesAsync();
            return apontamentoModel;
        }

        public async Task<ApontamentoModel> Atualizar(ApontamentoModel apontamentoModel)
        {
            _dbContext.Entry(apontamentoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return apontamentoModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var apontamento = await BuscarPorId(id);
            _dbContext.Apontamento.Remove(apontamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }               
    }
}
