using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services
{
    public class ParceiroService : IParceiroService
    {
        private IParceiroRepository _repository;

        public ParceiroService(IParceiroRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteParceiro(long id)
        {
            var parceiro = await _repository.FindAsync(id);
            if (parceiro != null)
            {
                await _repository.Delete(parceiro);
            }
            else
            {
                throw new Exception("Parceiro não encontrado");
            }
        }

        public async Task<Parceiro> FindParceiroById(long id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<Parceiro>> GetParceiros()
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

        public async Task<Parceiro> InsertParceiro(Parceiro parceiro)
        {
            try
            {

                await _repository.Add(parceiro);
                return parceiro;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir parceiro no sistema.");
            }
        }

        public async Task UpdateParceiro(Parceiro parceiro)
        {
            try
            {
                await _repository.Update(parceiro);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar parceiro no sistema.");
            }
        }
    }
}
