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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

 

        public async Task<Usuario> FindByIdNoTracking(long idUser)
        {
            return await _unitOfWork.Context.Set<Usuario>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == idUser);
        }

        public async Task<Usuario> FindUserByLogin(string email, string senha)
        {
            IQueryable<Usuario> query = _unitOfWork.Context.Set<Usuario>().Where(x => x.Email == email && x.Senha == senha);
            return await query.FirstOrDefaultAsync();
        }
    }
}
