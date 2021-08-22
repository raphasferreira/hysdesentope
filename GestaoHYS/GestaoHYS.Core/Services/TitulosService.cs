using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services
{
    public class TitulosService : ITitulosService
    {
        private ITitulosRepository _repository;
        private ISalesInvoiceRepository _salesInvoiceRepository;
        private IPagamentosRepository _pagamentosRepository;

        public TitulosService(ITitulosRepository repository, ISalesInvoiceRepository salesInvoiceRepository,
            IPagamentosRepository pagamentosRepository)
        {
            _repository = repository;
            _salesInvoiceRepository = salesInvoiceRepository;
            _pagamentosRepository = pagamentosRepository;
        }


        public async Task<Titulos> FindTitulosById(long id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<Titulos>> GetTitulos()
        {
            try
            {
                return await _repository.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateTitulos(Titulos titulos)
        {
            try
            {
                await AtualizaSalesInvoice(titulos.SalesInvoiceId);

                titulos.StatusTitulo = StatusTitulo.Liquidado;
               
                await _repository.Update(titulos);

                await CriaPagamento(titulos);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Titulos no sistema.");
            }
        }

        private async Task CriaPagamento(Titulos titulos)
        {
            try
            {
                var pagamento = new Pagamentos()
                {
                    DataPagamento = DateTime.Now,
                    TitulosId = titulos.IdTitulos,
                    ValorPagamento = titulos.ValorTotal
                };

                await _pagamentosRepository.Add(pagamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar pagamento no sistema.");
            }
        }

        private async Task AtualizaSalesInvoice(long salesInvoiceId)
        {
            try
            {
                var fatura = await _salesInvoiceRepository.FindAsync(salesInvoiceId);
                fatura.DocumentStatus = (int)DocumentStatus.Completed;
                fatura.DocumentStatusDescription = $"{DocumentStatus.Completed}";
                await _salesInvoiceRepository.UpdateAttached(fatura);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao atualizar status da Fatura no sistema.");
            }
        }
    }
}
