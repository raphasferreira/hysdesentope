using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GestaoHYS.Core.Repositories;
using MoreLinq;

namespace GestaoHYS.Core.Services
{
    public class SalesItemService : BaseService<SalesItem>, ISalesItemService
    {
        private ISalesItemWebService _webService;
        private ISalesItemRepository _repository;
        public SalesItemService(ISalesItemWebService webService, ISalesItemRepository repository) :
            base(repository)
        {
            _webService = webService;
            _repository = repository;
        }


        override
        public async Task<SalesItem> Insert(SalesItem salesItem)
        {
            try
            {
                var isPartKeyUnica = await VerificaPartyKeyIsUnica(salesItem.ItemKey);


                if (!isPartKeyUnica)
                {
                    throw new Exception("Nome de entidade deve ser única. Entidade informada cadastrada.");
                }

                await InsertBaseLocal(salesItem);

                if (salesItem.isIntegration)
                {
                    salesItem = await IntegrarSalesItem(salesItem);

                }

                return salesItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        override
        public async Task Update(SalesItem salesItem)
        {
            try
            {
                await UpdateBaseLocal(salesItem);

                if (salesItem.isIntegration)
                {
                    if (salesItem.isIntegrated)
                    {
                        await AtualizarSalesItem(salesItem);
                    }
                    else
                    {
                        await IntegrarSalesItem(salesItem);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task AtualizarSalesItem(SalesItem salesItem)
        {
            try
            {
                salesItem = await _webService.Update(salesItem);
                _repository.UpdateAttached(salesItem);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar artigo de venda com Jasmin. Ex.: " + ex.Message);
            }
        }

        private async Task UpdateBaseLocal(SalesItem salesItem)
        {
            await _repository.UpdateAttached(salesItem);
        }

        private async Task<SalesItem> IntegrarSalesItem(SalesItem salesItem)
        {
            try
            {

                salesItem = await _webService.Insert(salesItem);
                await AtualizarSalesItemIntegrado(salesItem);
                return salesItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao integrar artigo de venda com Jasmin. Ex.: " + ex.Message);
            }

        }

        private async Task<Boolean> VerificaPartyKeyIsUnica(string partyKey)
        {
            return await _repository.FindPartyKey(partyKey) == null;
        }

        private async Task AtualizarSalesItemIntegrado(SalesItem salesItem)
        {
            salesItem.isIntegrated = salesItem.ErrosIntegracao == null;
            salesItem.isIntegration = true;
            await _repository.UpdateAttached(salesItem);
        }

        private async Task InsertBaseLocal(SalesItem salesItem)
        {
            try
            {
                salesItem.isIntegrated = false;
                await _repository.Add(salesItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir artigo de venda na base local. Ex.: " + ex.Message);
            }

        }

        public async Task<IList<SalesItem>> GetAllSalesItem()
        {
            IList<SalesItem> salesItemResult = await _repository.FindAll();
            return salesItemResult;
        }

        public async Task<List<SalesItem>> FindAllAtivo()
        {
            List<SalesItem> listJasmin = (await _webService.GetAll()).ToList();
            listJasmin.AddRange(await _repository.FindAllAtivo());

            return listJasmin.ToList();
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
