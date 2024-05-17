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
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário {id} não foi encontrado no banco de dados.");
            }

            if (!Enum.IsDefined(typeof(UserType), usuarioModel.Type))
            {
                throw new ArgumentException("Tipo de usuário inválido");
            }

            usuarioPorId.Nome = usuarioModel.Nome;
            usuarioPorId.Senha = usuarioModel.Senha;
            usuarioPorId.Email = usuarioModel.Email;
            usuarioPorId.Type = usuarioModel.Type; // Atualizar o tipo de usuário

            _dbContext.Usuario.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário {id} não foi encontrado");
            }

            _dbContext.Usuario.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Autenticacao(LoginModel loginModel)
        {
            return await _dbContext.Usuario.Where(u => u.Email == loginModel.Email && u.Senha == loginModel.Senha).FirstOrDefaultAsync();
        }

    }

}
