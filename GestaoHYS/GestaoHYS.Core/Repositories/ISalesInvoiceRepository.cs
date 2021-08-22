using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Repositories
{
    public interface ISalesInvoiceRepository : IRepository<SalesInvoice>
    {
        Task<List<SalesInvoice>> FindAllAtivo();
        Task UpdateAttached(SalesInvoice entity);
        Task<IList<SalesInvoice>> BuscaFaturasAbertasLocais();
    }
}
