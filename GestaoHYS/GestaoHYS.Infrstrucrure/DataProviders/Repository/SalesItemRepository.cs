using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Infrastructure.DataProviders.Repository
{
    public class SalesItemRepository : Repository<SalesItem>, ISalesItemRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SalesItem>> FindAllAtivo()
        {
            try
            {
                return await _unitOfWork.Context.Set<SalesItem>().Where(w => (!w.IsDeleted)).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<SalesItem> FindPartyKey(string partyKey)
        {
            try
            {
                return await _unitOfWork.Context.Set<SalesItem>().FirstOrDefaultAsync(w => w.ItemKey.Equals(partyKey));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAttached(SalesItem entity)
        {
            this.DetachLocal(entity);
            await base.SetUpdate(entity);

        }

        public void DetachLocal(SalesItem entity)
        {
            var local = _unitOfWork.Context.Set<SalesItem>().Local
                .FirstOrDefault(entry => entry.Id.Equals(entry.Id));

            if (local != null)
            {
                _unitOfWork.Context.Entry(local).State = EntityState.Detached;
            }
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
