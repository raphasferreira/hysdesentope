using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> FindUserByLogin(string email, string senha);
        Task<Usuario> FindUserById(long id);

        Task<Usuario> InsertUser(Usuario usuario);
        Task UpdateUser(Usuario usuario);

        Task DeleteUsuario(long id);

        Task<List<Usuario>> GetUsuarios();
    }
}
