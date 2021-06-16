using GestaoHYS.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales
{
    public interface ICustomersClient
    {
        [Get("/salesCore/customerParties")]
        Task<List<Cliente>> GetAll();
    }
}
