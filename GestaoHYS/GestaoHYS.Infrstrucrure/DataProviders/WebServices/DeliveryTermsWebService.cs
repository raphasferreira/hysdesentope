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
    public class DeliveryTermsWebService : IDeliveryTermsWebService
    {
        private IDeliveryTermsClient _client;

        public DeliveryTermsWebService(IDeliveryTermsClient client)
        {
            _client = client;
      
        }


        public async Task<IList<DeliveryTerms>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos as condição de envio. { ex.Message } ");
            }
        }
    }
}
