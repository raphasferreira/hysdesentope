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
    public class CustomerWebService : ICustomerWebService
    {
        private ICustomersClient _client;

        public CustomerWebService(ICustomersClient client)
        {
            _client = client;
      
        }


        public async Task<IList<Cliente>> GetAll()
        {
            try
            {
                var resultrefit = _client.GetAll().Result;
                return resultrefit;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os cliente. { ex.Message } ");
            }
        }


        public async Task Delete(string clienteId)
        {
            try
            {
                var resultrefit = _client.Delete(clienteId).Result;

                if (!resultrefit.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao deletar cliente no Jasmin. {  resultrefit.Error.Content } ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente no Jasmin. { ex.Message } ");
            }
        }

        public async Task<Cliente> Insert(Cliente cliente)
        {
            try
            {
                var resultrefit = _client.Insert(cliente).Result;

                if (resultrefit.IsSuccessStatusCode)
                {
                    var idClient = resultrefit.Content.Replace("\"", "").Trim();
                    var clienteResult = _client.FindById(idClient).Result;
                    clienteResult.Id = cliente.Id;
                    clienteResult.ErrosIntegracao = null;
                    return clienteResult;
                }
                else
                {
                    cliente.ErrosIntegracao = resultrefit.Error.Content;
                    return cliente;
                }
   
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente no Jasmin. { ex.Message } ");
            }
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            try
            {
                cliente.ErrosIntegracao = null;

                foreach (var prop in cliente.GetType().BaseType.GetProperties())
                {
                    var valorItem = prop.GetValue(cliente, null);

                    ApiResponse<ActionResult> resultrefit;

                    if (prop.DeclaringType.Name.Equals("ClientePropriedadesAtualizacao"))
                    {
                        resultrefit = _client.Update(cliente.PartyKey, prop.Name, valorItem?.ToString()).Result;
                    }
                    else
                    {
                        resultrefit = _client.UpdateSalesCore(cliente.PartyKey, prop.Name, valorItem?.ToString()).Result;
                    }


                    if (!resultrefit.IsSuccessStatusCode)
                    {
                        cliente.ErrosIntegracao += resultrefit.Error.Content + "\n ";
                
                    }
                    
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente no Jasmin. { ex.Message } ");
            }
        }

        public async Task<Cliente> GetByKey(string partyKey)
        {
            try
            {
                var resultrefit = _client.GetByKey(partyKey).Result;
                if (resultrefit.IsSuccessStatusCode)
                {
                    return resultrefit.Content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os cliente. { ex.Message } ");
            }
        }
    }
}
