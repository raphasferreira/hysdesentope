using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface ISalesItemService : IBaseService<SalesItem>
    {
        Task<IList<SalesItem>> GetAllSalesItem();
        Task<List<SalesItem>> FindAllAtivo();
    }
}
