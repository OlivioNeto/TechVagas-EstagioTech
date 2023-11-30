using Microsoft.EntityFrameworkCore;
using System;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class UsuarioRepositorio
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.Where(p => p.EmailUsuario != "devproduction@gmail.com").ToListAsync();
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.Where(p => p.usuarioId == id && p.EmailUsuario != "devproduction@gmail.com").FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<UsuarioModel>> BuscarPorEmail(string email)
        {
            return await _dbContext.Usuarios.Where(p => p.EmailUsuario.ToUpper().Contains(email.ToUpper()) && p.EmailUsuario != "devproduction@gmail.com").ToListAsync();
        }
        public async Task<UsuarioModel> Login(LoginModel login)
        {
            return await _dbContext.Usuarios.Where(p => p.EmailUsuario == login.Email && p.SenhaUsuario == login.Senha).FirstOrDefaultAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            _dbContext.Usuarios.Add(usuarioModel);
            await _dbContext.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel)
        {
            _dbContext.Entry(usuarioModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<UsuarioModel> Apagar(int id)
        {
            var usuarioModel = await BuscarPorId(id);
            _dbContext.Usuarios.Remove(usuarioModel);
            await _dbContext.SaveChangesAsync();
            return usuarioModel;
        }
    }
}
