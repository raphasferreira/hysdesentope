using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Infrastructure.DataProviders.Repository
{
    public class ConfigurationSystemRepository : Repository<ConfigurationSystem>, IConfigurationSystemRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationSystemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
    }
}
