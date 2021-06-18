using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Infrastructure.DataProviders.Repository
{
    public class PerfilUsuarioRepository : Repository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PerfilUsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
