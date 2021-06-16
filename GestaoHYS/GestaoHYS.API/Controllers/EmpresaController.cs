//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GestaoHIS.API.Model;
//using GestaoHIS.API.Repository;
//using System.Net.Http;
//using GestaoHIS.API.Helpers;
//using Newtonsoft.Json;
//using GestaoHIS.API.Extensions;
//using Microsoft.Extensions.Configuration;

//namespace GestaoHIS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmpresaController : ControllerBase
//    {

//        private readonly GestaoHISContext _context;
//        private readonly IGestaoHISRepository _repo;
//        //private readonly IConfiguration _config;
//        internal static AuthenticationProvider AuthenticationProvider { get; set; }

//        public EmpresaController(GestaoHISContext context, IGestaoHISRepository repo)//, IConfiguration config)
//        {
//            _context = context;
//            _repo = repo;
//            //_config = config;
//            AuthenticationProvider = new AuthenticationProvider("", "");
//        }


//        #region Public Properties

//        /// <summary>
//        /// Gets or sets the account key.
//        /// </summary>
//        public static string AccountKey { get; set; }

//        /// <summary>
//        /// Gets or sets the subscription key.
//        /// </summary>
//        public static string SubscriptionKey { get; set; }

//        /// <summary>
//        /// Gets or sets the culture key.
//        /// </summary>
//        public static string CultureKey { get; set; }


//        #endregion

//        // GET: api/Empresa
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresa()
//        {
//            return await _context.Empresas.Where(w => w.IsDeleted == false).ToListAsync();
//        }

//        // GET: api/Empresa/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Empresa>> GetEmpresa(string id)
//        {
//            try
//            {
//                var Empresa = await _context.Empresas.FindAsync(id);

//                if (Empresa == null)
//                {
//                    return NotFound();
//                }

//                return Empresa;
//            }
//            catch (Exception e)
//            {
//                return Conflict(e);
//                throw e;
//            }
           
//        }


//        [HttpGet("GetEmpresaAll")]
//        public async Task<ActionResult<Empresa[]>> GetEmpresaAll()
//        {
//            try
//            {
//                var Empresas = await _repo.GetAllEmpresaAsync();

//                if (Empresas == null)
//                {
//                    return NotFound();
//                }

//                return Empresas;
//            }
//            catch (Exception e)
//            {

//                return Conflict();
//                throw e;
//            }
           
//        }


//        [HttpPut("")]
//        public async Task<IActionResult> PutEmpresa(Empresa Empresa)
//        {
//            if (Empresa.Id <= 0)
//            {
//                return BadRequest();
//            }

//            _repo.Update(Empresa);

//            try
//            {
//                await _repo.SaveChangesAsync();

//                return Ok();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EmpresaExists(Empresa.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }


//        [HttpPost]
//        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa Empresa)
//        {
//            _repo.Add(Empresa);
//            await _repo.SaveChangesAsync();

//            return CreatedAtAction("GetEmpresa", new { id = Empresa.Id }, Empresa);
//        }


//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Empresa>> DeleteEmpresa(long id)
//        {
//            var Empresa = await _context.Empresas.FindAsync(id);
//            if (Empresa == null)
//            {
//                return NotFound();
//            }
//            Empresa.IsDeleted = true;
//            _repo.Update(Empresa);

//            try
//            {
//                await _repo.SaveChangesAsync();

//                return Ok(Empresa);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EmpresaExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }

//        private bool EmpresaExists(long id)
//        {
//            return _context.Empresas.Any(e => e.Id == id);
//        }
//    }
//}
