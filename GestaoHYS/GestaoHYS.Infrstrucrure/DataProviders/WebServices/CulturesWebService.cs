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
    public class CulturesWebService : ICulturesWebService
    {
        private ICulturesClient _client;

        public CulturesWebService(ICulturesClient client)
        {
            _client = client;
      
        }


        public async Task<IList<Cultures>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos as culturas. { ex.Message } ");
            }
        }
    }
}
