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
        [Get("/salescore/salesitems")]
        Task<List<SalesItem>> GetAll();

        [Post("/salesCore/salesItems")]
        Task<ApiResponse<string>> Insert([Body]SalesItem salesItemPartyResource);

        [Get("/salesCore/salesItems/{id}")]
        Task<SalesItem> FindById(string id);


        [Put("/salesCore/salesItems/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> Update(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);


        [Put("/businesscore/items/{id}/{propriedade}")]
        Task<ApiResponse<ActionResult>> UpdateBusinessCore(string id, string propriedade, [Body(BodySerializationMethod.Json)] string valor);

        [Delete("/salesCore/salesItemParties/{id}")]
        Task<ApiResponse<ActionResult>> Delete(string id);



    }
}
