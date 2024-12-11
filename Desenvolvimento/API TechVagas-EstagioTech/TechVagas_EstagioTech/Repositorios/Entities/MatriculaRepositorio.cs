using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly DBContext _dbContext;

        public MatriculaRepositorio(DBContext matriculaDBContex)
        {
            _dbContext = matriculaDBContex;
        }
        public async Task<MatriculaModel> BuscarPorAluno(int idAluno)
        {
            return await _dbContext.Matricula.Where(x => x.AlunoId == idAluno).FirstOrDefaultAsync();
        }
        public async Task<MatriculaModel> BuscarPorId(int id)
        {
            return await _dbContext.Matricula.Where(x => x.MatriculaId == id).FirstOrDefaultAsync();
        }
        public async Task<List<MatriculaModel>> BuscarTodasMatriculas()
        {
            return await _dbContext.Matricula.ToListAsync();
        }
        public async Task<MatriculaModel> Adicionar(MatriculaModel matriculaModel)
        {
            _dbContext.Matricula.Add(matriculaModel);
            await _dbContext.SaveChangesAsync();
            return matriculaModel;
        }
        public async Task<MatriculaModel> Atualizar(MatriculaModel matriculaModel)
        {
            _dbContext.Entry(matriculaModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return matriculaModel;
        }
        public async Task<bool> Apagar(int id)
        {
            var matriculas = await BuscarPorId(id);
            _dbContext.Matricula.Remove(matriculas);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
