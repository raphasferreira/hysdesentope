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
    public class CustomerService :  BaseService<Cliente>, ICustomerService
    {
        private ICustomerWebService _webService;
        private IClienteRepository _repository;
        public CustomerService(ICustomerWebService webService, IClienteRepository repository) :
            base(repository)
        {
            _webService = webService;
            _repository = repository;
        }


        override
        public async Task<Cliente> Insert(Cliente cliente)
        {
            try
            {
                var isPartKeyUnica = await VerificaPartyKeyIsUnica(cliente.PartyKey);


                if (!isPartKeyUnica)
                {
                    throw new Exception("Nome de entidade deve ser única. Entidade informada cadastrada.");
                }

                await InsertBaseLocal(cliente);

                if (cliente.isIntegration)
                {
                    cliente = await IntegrarCliente(cliente);

                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        override
        public async Task Update(Cliente cliente)
        {
            try
            {
                await UpdateBaseLocal(cliente);

                if (cliente.isIntegration)
                {
                    if (cliente.isIntegrated)
                    {
                        await AtualizarCliente(cliente);
                    }
                    else
                    {
                        await IntegrarCliente(cliente);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task AtualizarCliente(Cliente cliente)
        {
            try
            {
               await _webService.Update(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente com Jasmin. Ex.: " + ex.Message);
            }
        }

        private async Task UpdateBaseLocal(Cliente cliente)
        {
            await _repository.UpdateAttached(cliente);
        }

        private async Task<Cliente> IntegrarCliente(Cliente cliente)
        {
            try
            {

                cliente = await _webService.Insert(cliente);
                await AtualizarClienteIntegrado(cliente);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao integrar cliente com Jasmin. Ex.: "+ ex.Message);
            }
           
        }

        private async Task<Boolean> VerificaPartyKeyIsUnica(string partyKey)
        {
            return await _repository.FindPartyKey(partyKey) == null;
        }

        private async Task AtualizarClienteIntegrado(Cliente cliente)
        {
            cliente.isIntegrated = true;
            cliente.isIntegration = true;
            await _repository.UpdateAttached(cliente);
        }

        private async Task InsertBaseLocal(Cliente cliente)
        {
            try
            {
                cliente.isIntegrated = false;
                await _repository.Add(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao inserir cliente na base local. Ex.: " + ex.Message);
            }
           
        }

        public async Task<IList<Cliente>> GetAllCustomer()
        {
            IList<Cliente> customerResult = await _webService.GetAll();
            return customerResult;
        }

        public async Task<List<Cliente>> FindAllAtivo()
        {
            return await _repository.FindAllAtivo();
        }

        override
        public  async Task Delete(object id)
        {
            var entidade = await _repository.FindAsync(id);
            if (entidade != null)
            {
                entidade.IsDeleted = true;
                await _repository.Update(entidade);
            }
            else
            {
                throw new Exception("Registro não encontrado");
            }
        }

    }
}
