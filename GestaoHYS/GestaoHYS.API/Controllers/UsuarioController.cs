using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoHIS.API.Model;
using GestaoHIS.API.Repository;
using Microsoft.Extensions.Configuration;
using GestaoHIS.API.Helpers;
using System.Net.Http;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly GestaoHISContext _context;
        private readonly IGestaoHISRepository _repo;
        private readonly IConfiguration _config;
        internal static AuthenticationProvider AuthenticationProvider { get; set; }

        public UsuarioController(GestaoHISContext context, IConfiguration config, IGestaoHISRepository repo)
        {
            _context = context;
            _repo = repo;
            _config = config;
            AuthenticationProvider = new AuthenticationProvider("", "");
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // GET: api/Usuario/5
        [HttpGet("Login")]
        public async Task<ActionResult<Object>> Login(string email, string senha)
        {
            var usuario = await _repo.GetUsuarioByEmailAsync(email);

            if (usuario == null)
            {
                return NotFound("");
            }

            if (usuario.Senha == senha)
            {


                string tokenJasmin = string.Empty;

                await AuthenticationProvider.GetAccessTokenAsync();
                tokenJasmin = AuthenticationProvider.accessToken;
                var retorno = new
                {
                    token = tokenJasmin
                };
                return Ok(retorno);

            }


            return NoContent();
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

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
