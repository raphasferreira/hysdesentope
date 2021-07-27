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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> FindAllAtivo()
        {
            try
            {
                return await _unitOfWork.Context.Set<Cliente>().Where(w => (!w.IsDeleted) && (!w.isIntegration || (w.isIntegration && !w.isIntegrated))).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<Cliente> FindPartyKey(string partyKey)
        {
            try
            {
                return await _unitOfWork.Context.Set<Cliente>().FirstOrDefaultAsync(w => w.PartyKey.Equals(partyKey));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAttached(Cliente entity)
        {
            this.DetachLocal(entity);
            await base.SetUpdate(entity);

        }

        public void DetachLocal(Cliente entity)
        {
            var local = _unitOfWork.Context.Set<Cliente>().Local
                .FirstOrDefault(entry => entry.Id.Equals(entry.Id));

            if (local != null)
            {
                _unitOfWork.Context.Entry(local).State = EntityState.Detached;
            }
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
