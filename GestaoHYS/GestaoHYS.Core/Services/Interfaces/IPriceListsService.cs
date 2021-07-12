using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface IPriceListsService
    {
        Task<IList<PriceLists>> GetAllPriceLists();
    }
}
