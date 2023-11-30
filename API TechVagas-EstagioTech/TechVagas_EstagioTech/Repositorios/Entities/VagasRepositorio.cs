using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class VagasRepositorio : IVagasRepositorio
    {
        private readonly AppDbContext _dbContext;

        public VagasRepositorio(AppDbContext cargoDBContex)
        {
            _dbContext = cargoDBContex;
        }
        public async Task<VagasModel> BuscarPorId(int id)
        {
            return await _dbContext.Vagas.Where(x => x.VagasId == id).FirstOrDefaultAsync();
        }
        public async Task<List<VagasModel>> BuscarTodasVagas()
        {
            return await _dbContext.Vagas.ToListAsync();
        }
        public async Task<VagasModel> Adicionar(VagasModel vagasModel)
        {
            _dbContext.Vagas.Add(vagasModel);
            await _dbContext.SaveChangesAsync();
            return vagasModel;
        }
        public async Task<VagasModel> Atualizar(VagasModel vagasModel)
        {
            _dbContext.Entry(vagasModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return vagasModel;
        }
        public async Task<bool> Apagar(int id)
        {
            var vagas = await BuscarPorId(id);
            _dbContext.Vagas.Remove(vagas);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
