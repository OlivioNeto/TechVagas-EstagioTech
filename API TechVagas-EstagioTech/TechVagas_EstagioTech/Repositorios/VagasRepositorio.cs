using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios
{
    public class VagasRepositorio
    {
        private readonly DBContext _dbContext;

        public VagasRepositorio(DBContext cargoDBContex)
        {
            _dbContext = cargoDBContex;
        }
        public async Task<VagasModel> BuscarPorId(int id)
        {
            return await _dbContext.Vagas.FirstOrDefaultAsync(x => x.VagasId == id);
        }
        public async Task<List<VagasModel>> BuscarTodasVagas()
        {
            return await _dbContext.Vagas.ToListAsync();
        }
    }
}
