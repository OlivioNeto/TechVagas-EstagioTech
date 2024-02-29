using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class InstituicaoEnsinoRepositorio : IInstituicaoEnsinoRepositorio
    {
        private readonly DBContext _dbContext;

        public InstituicaoEnsinoRepositorio(DBContext instituicaoEnsinoDBContex)
        {
            _dbContext = instituicaoEnsinoDBContex;
        }
        public async Task<InstituicaoEnsinoModel> BuscarPorId(int id)
        {
            return await _dbContext.InstituicaoEnsino.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<InstituicaoEnsinoModel>> BuscarTodasInstituicoes()
        {
            return await _dbContext.InstituicaoEnsino.ToListAsync();
        }
        public async Task<InstituicaoEnsinoModel> Adicionar(InstituicaoEnsinoModel instituicaoEnsinoModel)
        {
            _dbContext.InstituicaoEnsino.Add(instituicaoEnsinoModel);
            await _dbContext.SaveChangesAsync();
            return instituicaoEnsinoModel;
        }
        public async Task<InstituicaoEnsinoModel> Atualizar(InstituicaoEnsinoModel instituicaoEnsinoModel)
        {
            _dbContext.Entry(instituicaoEnsinoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return instituicaoEnsinoModel;
        }
        public async Task<bool> Apagar(int id)
        {
            var instituicao = await BuscarPorId(id);
            _dbContext.InstituicaoEnsino.Remove(instituicao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
