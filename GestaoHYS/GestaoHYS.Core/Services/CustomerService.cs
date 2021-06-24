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
                entidade.IsDeleted = "true";
                await _repository.Update(entidade);
            }
            else
            {
                throw new Exception("Registro não encontrado");
            }
        }

    }
}
