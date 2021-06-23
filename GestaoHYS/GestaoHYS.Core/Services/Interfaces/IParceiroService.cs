using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface IParceiroService
    {
        
        Task<Parceiro> FindParceiroById(long id);

        Task<Parceiro> InsertParceiro(Parceiro parceiro);
        Task UpdateParceiro(Parceiro parceiro);

        Task DeleteParceiro(long id);

        Task<List<Parceiro>> GetParceiros();
    }
}
