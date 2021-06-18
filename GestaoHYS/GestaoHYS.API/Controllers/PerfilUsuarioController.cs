using GestaoHYS.Core.Models;
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
    //[Authorize]
    [AllowAnonymous]
    public class PerfilUsuarioController : ControllerBase
    {
        private IPerfilUsuarioService _service;


        public PerfilUsuarioController(IPerfilUsuarioService service)
        {
            _service = service;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilUsuario>>> GetUsuarios()
        {
            try
            {
                return Ok(await _service.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de perfil de usuário. Exception: { ex.Message }");
            }

        }

        // GET: api/PerfilUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilUsuario>> GetPerfilUsuario(long id)
        {
            try
            {
                var perfilUsuario = await _service.FindById(id);

                if (perfilUsuario == null)
                {
                    return NotFound();
                }

                return Ok(perfilUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar perfil usuário. Exception: { ex.Message }");
            }

        }

        // PUT: api/PerfilUsuario/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfilUsuario(long id, PerfilUsuario perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(perfil);
                return Ok("Perfil Usuario atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST: api/PerfilUsuario
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PerfilUsuario>> PostPerfilUsuario(PerfilUsuario perfil)
        {
            try
            {
                perfil = await _service.Insert(perfil);
                return CreatedAtAction("GetPerfilUsuario", new { id = perfil.Id }, perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/PerfilUsuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerfilUsuario(long id)
        {
            try
            {
                await _service.Delete(id);
                return Ok("Perfil Usuário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
