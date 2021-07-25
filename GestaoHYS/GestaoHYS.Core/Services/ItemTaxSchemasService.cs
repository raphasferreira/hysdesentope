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
    public class ItemTaxSchemasService : IItemTaxSchemasService
    {
        private IItemTaxSchemasWebService _webService;

        public ItemTaxSchemasService(IItemTaxSchemasWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<ItemTaxSchemas>> GetAllItemTaxSchemas()
        {
            IList<ItemTaxSchemas> result = await _webService.GetAll();
            return result;
        }

       

    }
}
