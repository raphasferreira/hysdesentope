using GestaoHYS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
            await _unitOfWork.Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
            await _unitOfWork.Context.SaveChangesAsync();
            
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.Context.SaveChangesAsync();
        }
    }
}
