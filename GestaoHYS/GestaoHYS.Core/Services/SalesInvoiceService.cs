using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GestaoHYS.Core.Repositories;

namespace GestaoHYS.Core.Services
{
    public class SalesInvoiceService : BaseService<SalesInvoice>, ISalesInvoiceService
    {
        private ISalesInvoiceWebService _webService;
        private ISalesInvoiceRepository _repository;
        public SalesInvoiceService(ISalesInvoiceWebService webService, ISalesInvoiceRepository repository) :
            base(repository)
        {
            _webService = webService;
            _repository = repository;
        }


        override
        public async Task<SalesInvoice> Insert(SalesInvoice salesInvoice)
        {
            try
            {
                await InsertBaseLocal(salesInvoice);

                if (salesInvoice.isIntegration)
                {
                    salesInvoice = await IntegrarSalesInvoice(salesInvoice);

                }

                return salesInvoice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        override
        public async Task Update(SalesInvoice salesInvoice)
        {
            try
            {
                await UpdateBaseLocal(salesInvoice);

                if (salesInvoice.isIntegration)
                {
                    if (!salesInvoice.isIntegrated)
                    {
                        await IntegrarSalesInvoice(salesInvoice);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateBaseLocal(SalesInvoice salesInvoice)
        {
            await _repository.UpdateAttached(salesInvoice);
        }

        private async Task<SalesInvoice> IntegrarSalesInvoice(SalesInvoice salesInvoice)
        {
            try
            {

                salesInvoice = await _webService.Insert(salesInvoice);
                await AtualizarSalesInvoiceIntegrado(salesInvoice);
                return salesInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao integrar artigo de venda com Jasmin. Ex.: " + ex.Message);
            }

        }

        private async Task AtualizarSalesInvoiceIntegrado(SalesInvoice salesInvoice)
        {
            salesInvoice.isIntegrated = salesInvoice.ErrosIntegracao == null;
            salesInvoice.isIntegration = true;
            await _repository.UpdateAttached(salesInvoice);
        }

        private async Task InsertBaseLocal(SalesInvoice salesInvoice)
        {
            try
            {
                salesInvoice.isIntegrated = false;
                await _repository.Add(salesInvoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir artigo de venda na base local. Ex.: " + ex.Message);
            }

        }

        public async Task<IList<SalesInvoice>> GetAllSalesInvoice()
        {
            IList<SalesInvoice> salesInvoiceResult = await _repository.FindAll();
            return salesInvoiceResult;
        }

        public async Task<List<SalesInvoice>> FindAllAtivo()
        {
            List<SalesInvoice> listJasmin = (await _webService.GetAll()).ToList();
            listJasmin.AddRange(await _repository.FindAllAtivo());
            return listJasmin;
        }

        override
        public async Task Delete(object id)
        {
            var entidade = await _repository.FindAsync(id);
            if (entidade != null)
            {
                if (entidade.isIntegration)
                {
                    if (entidade.isIntegrated)
                    {
                        await _webService.Delete(entidade.IdReferencia);
                    }
                }

                entidade.IsDeleted = true;
                await _repository.Update(entidade);
            }
            else
            {
                throw new Exception("Registro não encontrado");
            }
        }

    }
}
