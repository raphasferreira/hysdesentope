using AutoMapper;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.WebServices;
using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Platform;
using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices
{
    public class PartyWithholdingTaxSchemasWebService : IPartyWithholdingTaxSchemasWebService
    {
        private IPartyWithholdingTaxSchemasClient _client;

        public PartyWithholdingTaxSchemasWebService(IPartyWithholdingTaxSchemasClient client)
        {
            _client = client;
      
        }


        public async Task<IList<PartyWithholdingTaxSchemas>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos as tipo de reteção. { ex.Message } ");
            }
        }
    }
}
