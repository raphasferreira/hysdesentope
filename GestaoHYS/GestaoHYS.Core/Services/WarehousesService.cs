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
    public class WarehousesService : IWarehousesService
    {
        private IWarehousesWebService _webService;

        public WarehousesService(IWarehousesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Warehouses>> GetAllWarehouses()
        {
            IList<Warehouses> result = await _webService.GetAll();
            return result;
        }

       

    }
}
