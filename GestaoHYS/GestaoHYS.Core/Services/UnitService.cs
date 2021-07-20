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
    public class UnitService : IUnitService
    {
        private IUnitWebService _webService;

        public UnitService(IUnitWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Unit>> GetAllUnit()
        {
            IList<Unit> result = await _webService.GetAll();
            return result;
        }

       

    }
}
