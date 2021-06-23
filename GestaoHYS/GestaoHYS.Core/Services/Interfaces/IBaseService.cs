using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Insert(T entidade);
        Task Update(T entidade);

        Task Delete(object id);
        Task<T> FindById(object id);
        Task<List<T>> FindAll();

    }
}
