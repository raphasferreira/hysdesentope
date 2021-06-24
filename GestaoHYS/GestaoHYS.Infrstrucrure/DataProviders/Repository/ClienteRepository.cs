using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> FindAllAtivo()
        {
            return await _unitOfWork.Context.Set<Cliente>().Where(w => w.IsDeleted.ToLower().Equals("false") || w.IsDeleted.ToLower().Equals("0")).ToListAsync();
        }
    }
}
