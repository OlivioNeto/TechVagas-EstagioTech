using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly DBContext _dbContext;

        public AlunoRepositorio(DBContext cargoDBContex)
        {
            _dbContext = cargoDBContex;
        }

        public async Task<AlunoModel> BuscarPorId(int id)
        {
            return await _dbContext.Alunos.Where(x => x.AlunoId == id).FirstOrDefaultAsync();
        }

        public async Task<List<AlunoModel>> BuscarTodosAlunos()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<AlunoModel> Adicionar(AlunoModel alunoModel)
        {
            _dbContext.Alunos.Add(alunoModel);
            await _dbContext.SaveChangesAsync();
            return alunoModel;
        }

        public async Task<AlunoModel> Atualizar(AlunoModel alunoModel)
        {
            _dbContext.Entry(alunoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return alunoModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var aluno = await BuscarPorId(id);
            _dbContext.Alunos.Remove(aluno);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
