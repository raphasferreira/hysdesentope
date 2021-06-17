using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

        Task<T> FindAsync(object id);
        Task<List<T>> FindAll();
    }
}
