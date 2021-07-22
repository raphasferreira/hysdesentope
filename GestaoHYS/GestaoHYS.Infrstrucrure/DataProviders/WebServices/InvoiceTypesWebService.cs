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
    public class InvoiceTypesWebService : IInvoiceTypesWebService
    {
        private IInvoiceTypesClient _client;

        public InvoiceTypesWebService(IInvoiceTypesClient client)
        {
            _client = client;
      
        }


        public async Task<IList<InvoiceTypes>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar tipos de documentos. { ex.Message } ");
            }
        }
    }
}
