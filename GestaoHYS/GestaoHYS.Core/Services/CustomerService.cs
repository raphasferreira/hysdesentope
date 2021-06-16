using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GestaoHYS.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerWebService _webService;

        public CustomerService(ICustomerWebService webService)
        {
            _webService = webService;
        }

        public async Task<IList<Cliente>> GetAllCustomer()
        {
            IList<Cliente> customerResult = await _webService.GetAll();
            return customerResult;
        }
    }
}
