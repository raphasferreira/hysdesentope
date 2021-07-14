using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Repositories
{
    public interface ISalesItemRepository : IRepository<SalesItem>
    {
        Task<List<SalesItem>> FindAllAtivo();
        Task<SalesItem> FindPartyKey(string partyKey);
        Task UpdateAttached(SalesItem entity);
    }
}
