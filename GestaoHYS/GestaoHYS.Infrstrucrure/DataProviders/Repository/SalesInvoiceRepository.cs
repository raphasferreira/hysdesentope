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
    public class SalesInvoiceRepository : Repository<SalesInvoice>, ISalesInvoiceRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesInvoiceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SalesInvoice>> FindAllAtivo()
        {
            try
            {
                return await _unitOfWork.Context.Set<SalesInvoice>()
                    .Include(w => w.DocumentLines).ThenInclude(d => d.UnitPrice)
                    .Where(w => (!w.IsDeleted) && (!w.isIntegration || (w.isIntegration && !w.isIntegrated))).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task UpdateAttached(SalesInvoice entity)
        {
            this.DetachLocal(entity);
            await base.SetUpdate(entity);

        }

        public void DetachLocal(SalesInvoice entity)
        {
            var local = _unitOfWork.Context.Set<SalesInvoice>().Local
                .FirstOrDefault(entry => entry.Id.Equals(entry.Id));

            if (local != null)
            {
                _unitOfWork.Context.Entry(local).State = EntityState.Detached;
            }
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IList<SalesInvoice>> BuscaFaturasAbertasLocais()
        {
            return await _unitOfWork.Context.Set<SalesInvoice>().Where(s => !s.isIntegrated && s.DocumentStatus == (int)DocumentStatus.Open).ToListAsync();
        }
    }
}
