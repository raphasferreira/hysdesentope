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
    public class SeriesService : ISeriesService
    {
        private ISeriesWebService _webService;

        public SeriesService(ISeriesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Series>> GetAllSeries()
        {
            IList<Series> result = await _webService.GetAll();
            return result;
        }

       

    }
}
