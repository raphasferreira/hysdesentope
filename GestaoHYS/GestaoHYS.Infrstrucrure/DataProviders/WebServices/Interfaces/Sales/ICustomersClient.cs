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


        [Put("/businesscore/parties/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> Update(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);

        [Put("/salescore/customerparties/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> UpdateSalesCore(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);

        [Delete("/salesCore/customerParties/{id}")]
        Task<ApiResponse<ActionResult>> Delete(string id);

        [Get("/salesCore/customerParties/{partyKey}")]
        Task<ApiResponse<Cliente>> GetByKey(string partyKey);
    }
}
