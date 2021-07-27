using AutoMapper;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.WebServices;
using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices
{
    public class SalesInvoiceWebService : ISalesInvoiceWebService
    {
        private ISalesInvoiceClient _client;

        public SalesInvoiceWebService(ISalesInvoiceClient client)
        {
            _client = client;
      
        }


        public async Task<IList<SalesInvoice>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os salesItem. { ex.Message } ");
            }
        }


        public async Task Delete(string salesItemId)
        {
            try
            {
                var resultrefit = _client.Delete(salesItemId).Result;

                if (!resultrefit.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao deletar salesItem no Jasmin. {  resultrefit.Error.Content } ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir salesItem no Jasmin. { ex.Message } ");
            }
        }

        public async Task<SalesInvoice> Insert(SalesInvoice salesItem)
        {
            try
            {
                var resultrefit = _client.Insert(salesItem).Result;

                if (resultrefit.IsSuccessStatusCode)
                {
                    var idClient = resultrefit.Content.Replace("\"", "").Trim();
                    var salesItemResult = _client.FindById(idClient).Result;
                    salesItemResult.Id = salesItem.Id;
                    salesItemResult.ErrosIntegracao = null;
                    return salesItemResult;
                }
                else
                {
                    salesItem.ErrosIntegracao = resultrefit.Error.Content;
                    return salesItem;
                }
   
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir salesItem no Jasmin. { ex.Message } ");
            }
        }

       
    }
}
