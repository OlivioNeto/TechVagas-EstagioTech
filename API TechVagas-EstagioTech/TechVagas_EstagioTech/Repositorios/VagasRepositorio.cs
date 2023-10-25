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
        public async Task<VagasModel> Adicionar(VagasModel vagas)
        {
            await _dbContext.Vagas.AddAsync(vagas);
            await _dbContext.SaveChangesAsync();

            return vagas;
        }
        public async Task<VagasModel> Atualizar(VagasModel vagas)
        {
            VagasModel VagasPorId = await BuscarPorId(vagas.VagasId);

            if (VagasPorId == null)
            {
                throw new Exception($"O id: {vagas.VagasId} da vaga não foi encontrado no banco");
            }
            VagasPorId.Descricao = vagas.Descricao;

            _dbContext.Vagas.Update(VagasPorId);
            await _dbContext.SaveChangesAsync();

            return VagasPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            VagasModel VagasPorId = await BuscarPorId(id);

            if (VagasPorId == null)
            {
                throw new Exception($"O id: {id} do cargo não foi encontrado no banco");
            }

            _dbContext.Vagas.Remove(VagasPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
