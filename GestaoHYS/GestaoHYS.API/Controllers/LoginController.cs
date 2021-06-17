using GestaoHYS.API.Helpers;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHYS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _servico;

        public LoginController(IUsuarioService servico)
        {
            _servico = servico;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticar([FromServices] IConfigurationSystemRepository systemRepository, string email, string senha)
        {
            try
            {

                var registro = await _servico.FindUserByLogin(email, senha);

                if (registro == null)
                {
                    return NotFound(new { message = "Usuário ou email inválidos" });
                }

                var token = await TokenServico.GenerateToken(registro, systemRepository);
                registro.Senha = null;

                return new
                {
                    usuario = registro,
                    token = token
                };

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
