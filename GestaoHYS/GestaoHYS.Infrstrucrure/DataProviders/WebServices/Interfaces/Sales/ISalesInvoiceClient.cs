using GestaoHYS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales
{
    public interface ISalesInvoiceClient
    {
        [Get("/billing/invoices")]
        Task<List<SalesInvoice>> GetAll();

        [Post("/billing/invoices/")]
        Task<ApiResponse<string>> Insert([Body]SalesInvoice salesInvoicePartyResource);

        [Get("/billing/invoices/{id}")]
        Task<SalesInvoice> FindById(string id);

        [Delete("/billing/invoices/{id}")]
        Task<ApiResponse<ActionResult>> Delete(string id);

    }
}
