using GestaoHYS.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Platform
{
    public interface IItemWithholdingTaxSchemasClient
    {
        [Get("/taxesCore/itemWithholdingTaxSchemas")]
        Task<List<ItemWithholdingTaxSchemas>> GetAll();
    }
}
