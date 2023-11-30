using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class ConcedenteRepositorio : IConcedenteRepositorio
    {
        private readonly AppDbContext _dbContext;

        public ConcedenteRepositorio(AppDbContext concedenteDBContex)
        {
            _dbContext = concedenteDBContex;
        }

        public async Task<ConcedenteModel> BuscarPorId(int id)
        {
            return await _dbContext.Concedentes.Where(x => x.concedenteId == id).FirstOrDefaultAsync();
        }

        public async Task<List<ConcedenteModel>> BuscarTodosConcedentes()
        {
            return await _dbContext.Concedentes.ToListAsync();
        }

        public async Task<ConcedenteModel> Adicionar(ConcedenteModel concedenteModel)
        {
            _dbContext.Concedentes.Add(concedenteModel);
            await _dbContext.SaveChangesAsync();
            return concedenteModel;
        }

        public async Task<ConcedenteModel> Atualizar(ConcedenteModel concedenteModel)
        {
            _dbContext.Entry(concedenteModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return concedenteModel;
        }

        public async Task<bool> Apagar(int id)
        {
            var concedente = await BuscarPorId(id);
            _dbContext.Concedentes.Remove(concedente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
