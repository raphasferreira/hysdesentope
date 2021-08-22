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
    public class TitulosRepository : Repository<Titulos>, ITitulosRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TitulosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        
    }
}
