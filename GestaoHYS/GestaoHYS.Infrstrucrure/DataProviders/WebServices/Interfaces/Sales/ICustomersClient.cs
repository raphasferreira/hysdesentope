using GestaoHYS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales
{
    public interface ICustomersClient
    {
        [Get("/salesCore/customerParties")]
        Task<List<Cliente>> GetAll();

        [Post("/salescore/customerParties")]
        Task<ApiResponse<string>> Insert([Body]Cliente customerPartyResource);

        [Get("/salesCore/customerParties/{id}")]
        Task<Cliente> FindById(string id);

        [Put("/salescore/customerParties")]
        Task<ApiResponse<string>> Update(Cliente cliente);
    }
}
