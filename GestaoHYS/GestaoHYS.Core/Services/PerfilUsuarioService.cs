using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Core.Services
{
    public class PerfilUsuarioService : BaseService<PerfilUsuario>, IPerfilUsuarioService
    {
        private IPerfilUsuarioRepository _repository;

        public PerfilUsuarioService(IPerfilUsuarioRepository repository):
            base(repository)
        {
            _repository = repository;
        }
    }
}
