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
    public class PartyWithholdingTaxSchemasService : IPartyWithholdingTaxSchemasService
    {
        private IPartyWithholdingTaxSchemasWebService _webService;

        public PartyWithholdingTaxSchemasService(IPartyWithholdingTaxSchemasWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<PartyWithholdingTaxSchemas>> GetAllPartyWithholdingTaxSchemas()
        {
            IList<PartyWithholdingTaxSchemas> result = await _webService.GetAll();
            return result;
        }

       

    }
}
