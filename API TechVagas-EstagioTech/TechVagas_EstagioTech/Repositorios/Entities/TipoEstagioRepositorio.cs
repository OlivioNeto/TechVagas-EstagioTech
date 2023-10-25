using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class TipoEstagioRepositorio : ITipoEstagioInterface
    {
        private readonly DBContext _dbContext;
        public TipoEstagioRepositorio(DBContext tipoEstagioDBContex)
        {
            _dbContext = tipoEstagioDBContex;
        }

        public async Task<TipoEstagioModel> BuscarPorId(int id)
        {
            return await _dbContext.TipoEstagio.FirstOrDefaultAsync(x => x.idTipoEstagio == id);
        }

        public async Task<List<TipoEstagioModel>> BuscarTodosTiposEstagios()
        {
            return await _dbContext.TipoEstagio.ToListAsync();
        }

        public async Task<TipoEstagioModel> Adicionar(TipoEstagioModel tipoEstagio)
        {
            await _dbContext.TipoEstagio.AddAsync(tipoEstagio);
            await _dbContext.SaveChangesAsync();

            return tipoEstagio;
        }

        public async Task<TipoEstagioModel> Atualizar(TipoEstagioModel tipoEstagio)
        {
            TipoEstagioModel tipoEstagioPorId = await BuscarPorId(tipoEstagio.idTipoEstagio);

            if (tipoEstagioPorId == null)
            {
                throw new Exception($"O id: {tipoEstagio.idTipoEstagio} do tipo estágio não foi encontrado no banco");
            }
            tipoEstagioPorId.descricaoTipoEstagio = tipoEstagio.descricaoTipoEstagio;

            _dbContext.TipoEstagio.Update(tipoEstagioPorId);
            await _dbContext.SaveChangesAsync();

            return tipoEstagioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoEstagioModel tipoEstagioPorId = await BuscarPorId(id);

            if (tipoEstagioPorId == null)
            {
                throw new Exception($"O id: {id} do tipo estágio não foi encontrado no banco");
            }

            _dbContext.TipoEstagio.Remove(tipoEstagioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }        
    }
}
