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
    public class CurrenciesService : ICurrenciesService
    {
        private ICurrenciesWebService _webService;

        public CurrenciesService(ICurrenciesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Currencies>> GetAllCurrencies()
        {
            IList<Currencies> result = await _webService.GetAll();
            return result;
        }

       

    }
}
