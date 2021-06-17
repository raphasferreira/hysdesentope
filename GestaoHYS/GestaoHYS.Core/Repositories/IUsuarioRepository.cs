using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> FindUserByLogin(string email, string senha);
        Task<Usuario> FindByIdNoTracking(long idUser);
    }
}
