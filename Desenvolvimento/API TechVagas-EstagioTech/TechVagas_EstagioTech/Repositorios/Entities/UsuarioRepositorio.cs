using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public UsuarioRepositorio(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuario.Where(x => x.UsuarioId == id).FirstOrDefaultAsync();
        }

        public async Task<UsuarioModel> BuscarPorNome(string email)
        {
            return await _dbContext.Usuario.Where(x => x.Nome.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<List<UsuarioModel>> BuscarUsuario()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            if (!Enum.IsDefined(typeof(UserType), usuarioModel.UsuarioId))
            {
                throw new ArgumentException("Tipo de usuário inválido");
            }

            await _dbContext.Usuario.AddAsync(usuarioModel);
            await _dbContext.SaveChangesAsync();

            return usuarioModel;
        }

    }

}
