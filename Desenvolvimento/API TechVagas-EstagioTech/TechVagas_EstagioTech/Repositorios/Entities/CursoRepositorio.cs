using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly DBContext _dbContext;
        public CursoRepositorio(DBContext cursoDBContex)
        {
            _dbContext = cursoDBContex;
        }

        public async Task<CursoModel> BuscarPorId(int id)
        {
			return await _dbContext.Curso.Where(x => x.cursoid == id).FirstOrDefaultAsync();
		}

        public async Task<List<CursoModel>> BuscarTodosCursos()
        {
            return await _dbContext.Curso.ToListAsync();
        }
        public async Task<CursoModel> Adicionar(CursoModel cursoModel)
        {
			_dbContext.Curso.Add(cursoModel);
			await _dbContext.SaveChangesAsync();
			return cursoModel;
		}

        public async Task<CursoModel> Atualizar(CursoModel cursoModel)
        {
			_dbContext.Entry(cursoModel).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return cursoModel;
		}

        public async Task<bool> Apagar(int id)
        {
			var curso = await BuscarPorId(id);
			_dbContext.Curso.Remove(curso);
			await _dbContext.SaveChangesAsync();
			return true;
		}   
    }
}
