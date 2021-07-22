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
    public class InvoiceTypesService : IInvoiceTypesService
    {
        private IInvoiceTypesWebService _webService;

        public InvoiceTypesService(IInvoiceTypesWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<InvoiceTypes>> GetAllInvoiceTypes()
        {
            IList<InvoiceTypes> result = await _webService.GetAll();
            return result;
        }

       

    }
}
