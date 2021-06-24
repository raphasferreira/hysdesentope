using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task Delete(object id)
        {
            var entidade = await _repository.FindAsync(id);
            if (entidade != null)
            {
                await _repository.Delete(entidade);
            }
            else
            {
                throw new Exception("Registro não encontrado");
            }
        }

        public  async Task<List<T>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<T> FindById(object id)
        {
            return await _repository.FindAsync(id);
        }

        public virtual async Task<T> Insert(T entidade)
        {
            try
            {
                await _repository.Add(entidade);
                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir registro no sistema.");
            }
        }

        public virtual async Task Update(T entidade)
        {
            try
            {
                await _repository.Update(entidade);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar registro no sistema.");
            }
        }
    }
}
