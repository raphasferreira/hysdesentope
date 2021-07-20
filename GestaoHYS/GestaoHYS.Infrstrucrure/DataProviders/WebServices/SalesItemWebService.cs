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
    public class SalesItemWebService : ISalesItemWebService
    {
        private ISalesItemClient _client;

        public SalesItemWebService(ISalesItemClient client)
        {
            _client = client;
      
        }


        public async Task<IList<SalesItem>> GetAll()
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

        public async Task<SalesItem> Insert(SalesItem salesItem)
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

        public async Task<SalesItem> Update(SalesItem salesItem)
        {
            try
            {
                salesItem.ErrosIntegracao = null;

                foreach (var prop in salesItem.GetType().BaseType.GetProperties())
                {
                    var valorItem = prop.GetValue(salesItem, null);

                    ApiResponse<ActionResult> resultrefit;

                    if (prop.DeclaringType.Name.Equals("SalesItemPropriedadesAtualizacao"))
                    {
                        resultrefit = _client.Update(salesItem.ItemKey, prop.Name, valorItem?.ToString()).Result;
                    }
                    else
                    {
                        resultrefit = _client.UpdateBusinessCore(salesItem.ItemKey, prop.Name, valorItem?.ToString()).Result;
                    }

                    if (!resultrefit.IsSuccessStatusCode)
                    {
                        salesItem.ErrosIntegracao += resultrefit.Error.Content + "\n ";
                
                    }
                    
                }
                return salesItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir salesItem no Jasmin. { ex.Message } ");
            }
        }
    }
}
