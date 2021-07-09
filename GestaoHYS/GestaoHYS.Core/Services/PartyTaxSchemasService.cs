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
    public class PartyTaxSchemasService : IPartyTaxSchemasService
    {
        private IPartyTaxSchemasWebService _webService;

        public PartyTaxSchemasService(IPartyTaxSchemasWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<PartyTaxSchemas>> GetAllPartyTaxSchemas()
        {
            IList<PartyTaxSchemas> result = await _webService.GetAll();
            return result;
        }

       

    }
}
