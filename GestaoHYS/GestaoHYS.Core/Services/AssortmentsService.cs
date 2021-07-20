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
    public class AssortmentsService : IAssortmentsService
    {
        private IAssortmentsWebService _webService;

        public AssortmentsService(IAssortmentsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<Assortments>> GetAllAssortments()
        {
            IList<Assortments> result = await _webService.GetAll();
            return result;
        }

       

    }
}
