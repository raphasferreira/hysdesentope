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
    public class CustomerGroupService : ICustomerGroupService
    {
        private ICustomerGroupWebService _webService;

        public CustomerGroupService(ICustomerGroupWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<CustomerGroup>> GetAllCustomerGroup()
        {
            IList<CustomerGroup> result = await _webService.GetAll();
            return result;
        }

       

    }
}
