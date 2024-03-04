using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class CoordenadorEstagioRepositorio : ICoordenadorEstagioRepositorio
    {
        private readonly DBContext _dbContext;
        public CoordenadorEstagioRepositorio(DBContext coordenadorEstagioDBContex)
        {
            _dbContext = coordenadorEstagioDBContex;
        }

        public async Task<CoordenadorEstagioModel> BuscarPorId(int id)
        {
            return await _dbContext.CoordenadorEstagio.Where(x => x.idCoordenadorEstagio == id).FirstOrDefaultAsync();
        }
        public async Task<List<CoordenadorEstagioModel>> BuscarTodosCoordenadores()
        {
            return await _dbContext.CoordenadorEstagio.ToListAsync();
        }
        public async Task<CoordenadorEstagioModel> Adicionar(CoordenadorEstagioModel coordenadorEstagioModel)
        {
            _dbContext.CoordenadorEstagio.Add(coordenadorEstagioModel);
            await _dbContext.SaveChangesAsync();
            return coordenadorEstagioModel;
        }
        public async Task<CoordenadorEstagioModel> Atualizar(CoordenadorEstagioModel coordenadorEstagioModel)
        {
            _dbContext.Entry(coordenadorEstagioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return (coordenadorEstagioModel);
        }

        public async Task<bool> Apagar(int id)
        {
            var coordenadorEstagio = await BuscarPorId(id);
            _dbContext.CoordenadorEstagio.Remove(coordenadorEstagio);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
    }
}
