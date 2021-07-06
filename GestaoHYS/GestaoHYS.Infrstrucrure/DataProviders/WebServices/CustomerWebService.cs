using AutoMapper;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.WebServices;
using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                    return clienteResult;
                }
                else
                {
                    
                    throw new Exception($"Erro ao inserir cliente no Jasmin. { resultrefit.Error.Content }");
                }
   
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente no Jasmin. { ex.Message } ");
            }
        }

        public async Task Update(Cliente cliente)
        {
            try
            {
                var resultrefit = _client.Update(cliente).Result;

                if (!resultrefit.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao atualizar cliente no Jasmin. { resultrefit.Error.Content }");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente no Jasmin. { ex.Message } ");
            }
        }
    }
}
