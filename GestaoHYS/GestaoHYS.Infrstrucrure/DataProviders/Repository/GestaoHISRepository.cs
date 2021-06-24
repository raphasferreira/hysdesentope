//using GestaoHYS.Core.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GestaoHIS.Infrastructure.Repository
//{
//    public class GestaoHISRepository : IGestaoHISRepository
//    {
//        #region Generic Methods
//        private readonly GestaoHISContext _context;
//        public GestaoHISRepository(GestaoHISContext context)
//        {
//            _context = context;
//            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
//        }

//        public void Add<T>(T entity) where T : class
//        {
//            _context.Add(entity);
//        }

//        public void Update<T>(T entity) where T : class
//        {
//            _context.Update(entity);
//        }

//        public void Delete<T>(T entity) where T : class
//        {
//            _context.Remove(entity);
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return (await _context.SaveChangesAsync()) > 0;
//        }
//        #endregion

//        #region Endereco
//        public async Task<Endereco[]> GetAllEnderecosAsync()
//        {
//            IQueryable<Endereco> query = _context.Enderecos;
//            query = query.AsNoTracking()
//                        .OrderByDescending(c => c.Id);
//            return await query.ToArrayAsync();
//        }

//        public async Task<Endereco> GetEnderecoByIdAsync(long id)
//        {
//            IQueryable<Endereco> query = _context.Enderecos;
//            query = query.AsNoTracking().Where(x => x.Id == id);
//            return await query.FirstOrDefaultAsync();
//        }
//        #endregion

//        #region Usuario
//        public async Task<Usuario[]> GetAllUsuariosAsync()
//        {
//            IQueryable<Usuario> query = _context.Usuarios;
//            query = query.AsNoTracking()
//                        .OrderByDescending(c => c.Id);
//            return await query.ToArrayAsync();
//        }

//        public async Task<Usuario> GetUsuarioByIdAsync(long id)
//        {
//            IQueryable<Usuario> query = _context.Usuarios;
//            query = query.AsNoTracking().Where(x => x.Id == id);
//            return await query.FirstOrDefaultAsync();
//        }

//        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
//        {
//            IQueryable<Usuario> query = _context.Usuarios;
//            query = query.AsNoTracking().Where(x => x.Email == email);
//            return await query.FirstOrDefaultAsync();
//        }
//        #endregion

//        #region Cliente
//        //public async Task<Cliente[]> GetAllClienteAsync()
//        //{
//        //    IQueryable<Cliente> query = _context.Cliente;
//        //    query = query.AsNoTracking().Where(x => x.IsDeleted == false)
//        //                .OrderBy(c => c.PartyKey);
//        //    return await query.ToArrayAsync();
//        //}

//        #endregion

//        #region Empresa
//        public async Task<Empresa[]> GetAllEmpresaAsync()
//        {
//            IQueryable<Empresa> query = _context.Empresas;
//            query = query.AsNoTracking().Where(w => w.IsDeleted == false).OrderBy(c => c.Id);
//            return await query.ToArrayAsync();
//        }
//        #endregion
//    }
//}
