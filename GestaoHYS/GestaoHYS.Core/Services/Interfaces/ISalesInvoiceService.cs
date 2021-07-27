using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface ISalesInvoiceService : IBaseService<SalesInvoice>
    {
        Task<IList<SalesInvoice>> GetAllSalesInvoice();
        Task<List<SalesInvoice>> FindAllAtivo();
    }
}
