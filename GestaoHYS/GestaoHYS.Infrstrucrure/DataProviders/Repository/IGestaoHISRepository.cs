//using GestaoHYS.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GestaoHIS.Infrastructure.Repository
//{
//    public interface IGestaoHISRepository
//    {
//        #region Generic Methods
//        //Metodos Genéricos de Crud
//        void Add<T>(T entity) where T : class;
//        void Update<T>(T entity) where T : class;
//        void Delete<T>(T entity) where T : class;
//        Task<bool> SaveChangesAsync();
//        #endregion

//        #region Endereco
//        Task<Endereco[]> GetAllEnderecosAsync();
//        Task<Endereco> GetEnderecoByIdAsync(long id);
//        #endregion

//        #region Usuario
//        public Task<Usuario[]> GetAllUsuariosAsync();
//        public Task<Usuario> GetUsuarioByIdAsync(long id);
//        public Task<Usuario> GetUsuarioByEmailAsync(string email);

//        #endregion

//        #region Cliente
//        public Task<Cliente[]> GetAllClienteAsync();
//        #endregion

//        #region Empresa
//        public Task<Empresa[]> GetAllEmpresaAsync();
//        #endregion
//    }
//}
