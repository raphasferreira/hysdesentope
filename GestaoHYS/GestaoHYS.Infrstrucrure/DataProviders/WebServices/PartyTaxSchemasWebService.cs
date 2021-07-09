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
    public class PartyTaxSchemasWebService : IPartyTaxSchemasWebService
    {
        private IPartyTaxSchemasClient _client;

        public PartyTaxSchemasWebService(IPartyTaxSchemasClient client)
        {
            _client = client;
      
        }


        public async Task<IList<PartyTaxSchemas>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos as regime de imposto. { ex.Message } ");
            }
        }
    }
}
