using GestaoHYS.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Platform
{
    public interface IPartyWithholdingTaxSchemasClient
    {
        [Get("/taxesCore/partyWithholdingTaxSchemas")]
        Task<List<PartyWithholdingTaxSchemas>> GetAll();
    }
}
