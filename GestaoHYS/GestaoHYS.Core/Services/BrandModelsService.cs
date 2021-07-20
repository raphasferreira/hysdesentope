﻿using GestaoHYS.Core.Models;
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
    public class BrandModelsService : IBrandModelsService
    {
        private IBrandModelsWebService _webService;

        public BrandModelsService(IBrandModelsWebService webService) 
           
        {
            _webService = webService;
        }

        public async Task<IList<BrandModels>> GetAllBrandModels()
        {
            IList<BrandModels> result = await _webService.GetAll();
            return result;
        }

       

    }
}
