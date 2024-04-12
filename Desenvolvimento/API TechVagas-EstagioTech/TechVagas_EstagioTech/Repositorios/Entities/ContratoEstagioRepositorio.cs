using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class ContratoEstagioRepositorio
    {
        private readonly DBContext _dbContext;

        public ContratoEstagioRepositorio(DBContext contratoestagioDBContex)
        {
            _dbContext = contratoestagioDBContex;
        }

        public async Task<ContratoEstagioModel> BuscarPorId(int id)
        {
            return await _dbContext.ContratoEstagio.Where(x => x.idContratoEstagio == id).FirstOrDefaultAsync();
        }

        public async Task<List<ContratoEstagioModel>> BuscarTodosContratoEstagios()
        {
            return await _dbContext.ContratoEstagio.ToListAsync();
        }

        public async Task<ContratoEstagioModel> Adicionar(ContratoEstagioModel contratoestagioModel)
        {
            _dbContext.ContratoEstagio.Add(contratoestagioModel);
            await _dbContext.SaveChangesAsync();
            return contratoestagioModel;
        }

        public async Task<ContratoEstagioModel> Atualizar(ContratoEstagioModel contratoestagioModel)
        {
            _dbContext.Entry(contratoestagioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return contratoestagioModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var contratoestagio = await BuscarPorId(id);
            _dbContext.ContratoEstagio.Remove(contratoestagio);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
