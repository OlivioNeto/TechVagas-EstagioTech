using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
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
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuario.Where(objeto => objeto.UsuarioId != 1).ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuario.Where(objeto => objeto.UsuarioId == id && objeto.UsuarioId != 1).Include(objeto => objeto.UserTypeModel).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> BuscarPorEmail(int id, string email)
        {
            return await _dbContext.Usuario.Where(objeto => objeto.UsuarioId != id && objeto.Email.Contains(email) && objeto.UsuarioId != 1).ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            _dbContext.Usuario.Add(usuarioModel);
            await _dbContext.SaveChangesAsync();
            return usuarioModel;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(usuarioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<UsuarioModel> Login(LoginModel loginModel)
        {
            return await _dbContext.Usuario.Where(objeto => objeto.Email == loginModel.Email && objeto.Senha == loginModel.Senha).Include(objeto => objeto.UserTypeModel).FirstOrDefaultAsync();
        }

        public async Task<UsuarioModel> Apagar(int id)
        {
            var usuario = await BuscarPorId(id);
            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

    }

}
