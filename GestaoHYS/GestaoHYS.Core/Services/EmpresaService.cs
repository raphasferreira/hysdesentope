using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteEmpresa(long id)
        {
            var empresa = await _repository.FindAsync(id);
            if (empresa != null)
            {
                await _repository.Delete(empresa);
            }
            else
            {
                throw new Exception("Empresa não encontrado");
            }
        }

        public async Task<Empresa> FindEmpresaById(long id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<Empresa>> GetEmpresas()
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

        public async Task<Empresa> InsertEmpresa(Empresa empresa)
        {
            try
            {

                await _repository.Add(empresa);
                return empresa;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir empresa no sistema.");
            }
        }

        public async Task UpdateEmpresa(Empresa empresa)
        {
            try
            {
                await _repository.Update(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar empresa no sistema.");
            }
        }
    }
}
