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
    public class BrandsService : IBrandsService
    {
        private IBrandsWebService _webService;

        public BrandsService(IBrandsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Brands>> GetAllBrands()
        {
            IList<Brands> result = await _webService.GetAll();
            return result;
        }

       

    }
}
