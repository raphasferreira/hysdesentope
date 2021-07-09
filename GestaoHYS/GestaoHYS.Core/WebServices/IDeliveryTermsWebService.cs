using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.WebServices
{
    public interface IDeliveryTermsWebService
    {
        Task<IList<DeliveryTerms>> GetAll();
    }
}
