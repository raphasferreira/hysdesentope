using GestaoHYS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales
{
    public interface ISalesItemClient
    {
        [Get("/salesCore/salesItemParties")]
        Task<List<SalesItem>> GetAll();

        [Post("/salescore/salesItemParties")]
        Task<ApiResponse<string>> Insert([Body]SalesItem salesItemPartyResource);

        [Get("/salesCore/salesItemParties/{id}")]
        Task<SalesItem> FindById(string id);


        [Put("/businesscore/parties/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> Update(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);

        [Put("/salescore/salesItemparties/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> UpdateSalesCore(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);

        [Delete("/salesCore/salesItemParties/{id}")]
        Task<ApiResponse<ActionResult>> Delete(string id);



    }
}
