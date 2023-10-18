using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly DBContex _dbContext;
        public CursoRepositorio(DBContex cursoDBContex)
        {
            _dbContext = cursoDBContex;
        }

        public async Task<CursoModel> BuscarPorId(int id)
        {
            return await _dbContext.Curso.FirstOrDefaultAsync(x => x.idCurso == id);
        }

        public async Task<List<CursoModel>> BuscarTodosTiposEstagios()
        {
            return await _dbContext.Curso.ToListAsync();
        }
        public async Task<CursoModel> Adicionar(CursoModel curso)
        {
            await _dbContext.Curso.AddAsync(curso);
            await _dbContext.SaveChangesAsync();

            return curso;
        }

        public async Task<CursoModel> Atualizar(CursoModel curso)
        {
            CursoModel CursoPorId = await BuscarPorId(curso.idCurso);

            if (CursoPorId == null)
            {
                throw new Exception($"O id: {curso.idCurso} do Curso não foi encontrado no banco");
            }
            CursoPorId.nomeCurso = curso.nomeCurso;

            _dbContext.Curso.Update(CursoPorId);
            await _dbContext.SaveChangesAsync();

            return CursoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            CursoModel CursoPorId = await BuscarPorId(id);

            if (CursoPorId == null)
            {
                throw new Exception($"O id: {id} do Curso não foi encontrado no banco");
            }

            _dbContext.Curso.Remove(CursoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }   
    }
}
