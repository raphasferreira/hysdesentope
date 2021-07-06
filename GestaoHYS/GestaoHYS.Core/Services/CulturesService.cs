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
    public class CulturesService : ICulturesService
    {
        private ICulturesWebService _webService;

        public CulturesService(ICulturesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Cultures>> GetAllCultures()
        {
            IList<Cultures> result = await _webService.GetAll();
            return result;
        }

       

    }
}
