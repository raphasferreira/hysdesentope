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
    public class PaymentTermsService : IPaymentTermsService
    {
        private IPaymentTermsWebService _webService;

        public PaymentTermsService(IPaymentTermsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<PaymentTerms>> GetAllPaymentTerms()
        {
            IList<PaymentTerms> result = await _webService.GetAll();
            return result;
        }

       

    }
}
