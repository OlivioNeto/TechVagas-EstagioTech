using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class VagasRepositorio : IVagasRepositorio
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
        public async Task<VagasModel> Adicionar(VagasModel vagasModel)
        {
            await _dbContext.Vagas.AddAsync(vagasModel);
            await _dbContext.SaveChangesAsync();

            return vagasModel;
        }
        public async Task<VagasModel> Atualizar(VagasModel vagasModel)
        {
            VagasModel VagasPorId = await BuscarPorId(vagasModel.VagasId);

            if (VagasPorId == null)
            {
                throw new Exception($"O id: {vagasModel.VagasId} da vaga não foi encontrado no banco");
            }
            VagasPorId.Descricao = vagasModel.Descricao;

            _dbContext.Vagas.Update(VagasPorId);
            await _dbContext.SaveChangesAsync();

            return VagasPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            VagasModel VagasPorId = await BuscarPorId(id);

            if (VagasPorId == null)
            {
                throw new Exception($"O id: {id} da vaga não foi encontrado no banco");
            }

            _dbContext.Vagas.Remove(VagasPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
