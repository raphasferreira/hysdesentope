using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface ITitulosService
    {
        
        Task<Titulos> FindTitulosById(long id);

        Task UpdateTitulos(Titulos Titulos);

        Task<List<Titulos>> GetTitulos();
    }
}
