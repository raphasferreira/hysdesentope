using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.WebServices
{
    public interface ISalesItemWebService
    {
        Task<IList<SalesItem>> GetAll();

        Task<SalesItem> Insert(SalesItem salesItem);
        Task<SalesItem> Update(SalesItem salesItem);
        Task Delete(string salesItemId);
    }
}
