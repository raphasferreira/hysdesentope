using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface ICustomerService : IBaseService<Cliente>
    {
        Task<IList<Cliente>> GetAllCustomer();
        Task<List<Cliente>> FindAllAtivo();
    }
}
