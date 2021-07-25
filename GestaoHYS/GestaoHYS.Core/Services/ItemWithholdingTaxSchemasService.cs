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
    public class ItemWithholdingTaxSchemasService : IItemWithholdingTaxSchemasService
    {
        private IItemWithholdingTaxSchemasWebService _webService;

        public ItemWithholdingTaxSchemasService(IItemWithholdingTaxSchemasWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<ItemWithholdingTaxSchemas>> GetAllItemWithholdingTaxSchemas()
        {
            IList<ItemWithholdingTaxSchemas> result = await _webService.GetAll();
            return result;
        }

       

    }
}
