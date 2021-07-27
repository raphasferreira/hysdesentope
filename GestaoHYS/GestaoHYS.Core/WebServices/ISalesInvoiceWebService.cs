using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.WebServices
{
    public interface ISalesInvoiceWebService
    {
        Task<IList<SalesInvoice>> GetAll();

        Task<SalesInvoice> Insert(SalesInvoice salesItem);
        Task Delete(string salesItemId);
    }
}
