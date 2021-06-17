using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using GestaoHIS.API.Helpers;
using System.Net.Http;
using GestaoHIS.Infrastructure.Repository;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.Models;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _service;


        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                return Ok(await _service.GetUsuarios());
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de usuários. Exception: { ex.Message }");
            }
            
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            try
            {
                var usuario = await _service.FindUserById(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário. Exception: { ex.Message }");
            }
            
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(long id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateUser(usuario);
                return Ok("Usuario atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

          
        }

        // POST: api/Usuario
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                usuario = await _service.InsertUser(usuario);
                return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(long id)
        {
            try
            {
                await _service.DeleteUsuario(id);
                return Ok("Usuário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  
    }
}
