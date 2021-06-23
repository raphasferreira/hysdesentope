using GestaoHYS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface IEmpresaService
    {
        
        Task<Empresa> FindEmpresaById(long id);

        Task<Empresa> InsertEmpresa(Empresa empresa);
        Task UpdateEmpresa(Empresa empresa);

        Task DeleteEmpresa(long id);

        Task<List<Empresa>> GetEmpresas();
    }
}
