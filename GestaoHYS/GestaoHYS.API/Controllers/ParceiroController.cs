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
//    public class ParceiroController : ControllerBase
//    {

//        private readonly GestaoHISContext _context;
//        private readonly IGestaoHISRepository _repo;
//        //private readonly IConfiguration _config;
//        internal static AuthenticationProvider AuthenticationProvider { get; set; }

//        public ParceiroController(GestaoHISContext context, IGestaoHISRepository repo)//, IConfiguration config)
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

//        // GET: api/Parceiro
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Parceiro>>> GetParceiro()
//        {
//            return await _context.Parceiros.Include(x => x.ParceiroPais).Where(w => w.IsDeleted == false).ToListAsync();
//        }

//        // GET: api/Parceiro/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Parceiro>> GetParceiro(long id)
//        {
//            try
//            {
//                var Parceiro = await _context.Parceiros.Include(x => x.ParceiroPais).Where(x => x.Id == id).FirstOrDefaultAsync();

//                if (Parceiro == null)
//                {
//                    return NotFound();
//                }

//                return Parceiro;
//            }
//            catch (Exception e)
//            {
//                return Conflict(e);
//                throw e;
//            }
           
//        }

//        [HttpPut("")]
//        public async Task<IActionResult> PutParceiro(Parceiro Parceiro)
//        {
//            if (Parceiro.Id <= 0)
//            {
//                return BadRequest();
//            }

//            if (!ParceiroExists(Parceiro.Id))
//            {
//                return NotFound();
//            }
//            _repo.Update(Parceiro);

//            try
//            {
//                await _repo.SaveChangesAsync();

//                return Ok();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ParceiroExists(Parceiro.Id))
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
//        public async Task<ActionResult<Parceiro>> PostParceiro(Parceiro Parceiro)
//        {
//            _repo.Add(Parceiro);
//            await _repo.SaveChangesAsync();

//            return CreatedAtAction("GetParceiro", new { id = Parceiro.Id }, Parceiro);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Parceiro>> DeleteEmpresa(long id)
//        {
//            var Parceiro = await _context.Parceiros.FindAsync(id);
//            if (Parceiro == null)
//            {
//                return NotFound();
//            }
//            Parceiro.IsDeleted = true;
//            _repo.Update(Parceiro);

//            try
//            {
//                await _repo.SaveChangesAsync();

//                return Ok(Parceiro);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ParceiroExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }

//        private bool ParceiroExists(long id)
//        {
//            return _context.Parceiros.Any(e => e.Id == id);
//        }
//    }
//}
