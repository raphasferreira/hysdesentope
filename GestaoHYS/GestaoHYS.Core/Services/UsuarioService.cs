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

        public async Task<Usuario> FindUserByLogin(string email, string senha)
        {
            return await _repository.FindUserByLogin(email, senha);
        }
    }
}
