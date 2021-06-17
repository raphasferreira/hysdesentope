using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteUsuario(long id)
        {
            var usuario = await _repository.FindAsync(id);
            if (usuario != null)
            {
                await _repository.Delete(usuario);
            }
            else
            {
                throw new Exception("Usuario não encontrado");
            }
        }

        public async Task<Usuario> FindUserById(long id)
        {
            return  await _repository.FindAsync(id); 
        }

        public async Task<Usuario> FindUserByLogin(string email, string senha)
        {
            var senhaMd5Hash = Helpers.GerarHashMd5(senha);
            return await _repository.FindUserByLogin(email, senhaMd5Hash);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _repository.FindAll();
        }

        public async Task<Usuario> InsertUser(Usuario usuario)
        {
            try
            {
                usuario.Senha = Helpers.GerarHashMd5(usuario.Senha);
                await _repository.Add(usuario);
                return usuario;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao inserir usuário no sistema.");
            }
        }

        public async Task UpdateUser(Usuario usuario)
        {
            try
            {
                Usuario userDB = await _repository.FindByIdNoTracking(usuario.Id);
                if(userDB != null)
                {
                    usuario.Senha = userDB.Senha;
                    await _repository.Update(usuario);
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar usuário no sistema.");
            }
        }
    }
}
