using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GestaoHYS.Core.Repositories;

namespace GestaoHYS.Core.Services
{
    public class PriceListsService : IPriceListsService
    {
        private IPriceListsWebService _webService;

        public PriceListsService(IPriceListsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<PriceLists>> GetAllPriceLists()
        {
            IList<PriceLists> result = await _webService.GetAll();
            return result;
        }

       

    }
}
