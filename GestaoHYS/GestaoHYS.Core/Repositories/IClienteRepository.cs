using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> FindAllAtivo();
        Task<Cliente> FindPartyKey(string partyKey);
        Task UpdateAttached(Cliente entity);
    }
}
