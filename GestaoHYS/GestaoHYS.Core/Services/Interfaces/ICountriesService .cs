﻿using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface ICountriesService
    {
        Task<IList<Countries>> GetAllCountries();
    }
}
