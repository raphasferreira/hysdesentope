using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.WebServices
{
    public interface ICustomerWebService
    {
        Task<IList<Cliente>> GetAll();
        Task<Cliente> GetByKey(string partyKey);

        Task<Cliente> Insert(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task Delete(string clienteId);
    }
}
