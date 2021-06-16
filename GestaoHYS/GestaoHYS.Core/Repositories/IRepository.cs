using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
