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
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private IPaymentMethodsWebService _webService;

        public PaymentMethodsService(IPaymentMethodsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<PaymentMethods>> GetAllPaymentMethods()
        {
            IList<PaymentMethods> result = await _webService.GetAll();
            return result;
        }

       

    }
}
