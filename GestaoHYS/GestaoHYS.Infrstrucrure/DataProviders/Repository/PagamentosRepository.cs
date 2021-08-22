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
    public class PagamentosRepository : Repository<Pagamentos>, IPagamentosRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PagamentosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        
    }
}
