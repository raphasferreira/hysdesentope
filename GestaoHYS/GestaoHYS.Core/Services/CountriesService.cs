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
    public class CountriesService : ICountriesService
    {
        private ICountriesWebService _webService;

        public CountriesService(ICountriesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Countries>> GetAllCountries()
        {
            IList<Countries> result = await _webService.GetAll();
            return result;
        }

       

    }
}
