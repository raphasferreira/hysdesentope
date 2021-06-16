//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GestaoHIS.API.Helpers;
//using GestaoHIS.API.Model;
//using GestaoHIS.API.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestaoHIS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SalesItemController : ControllerBase
//    {

//        private readonly GestaoHISContext _context;
//        internal static AuthenticationProvider AuthenticationProvider { get; set; }

//        public SalesItemController(GestaoHISContext context)
//        {
//            _context = context;

//            AuthenticationProvider = new AuthenticationProvider("", "");
//        }


//        // GET: api/SalesItem
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SalesItem>>> GetSalesItem()
//        {
//            return await _context.SalesItem.ToListAsync();
//        }

//        // GET: api/SalesItem/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SalesItem>> GetSalesItem(string id)
//        {
//            try
//            {
//                var SalesItem = await _context.SalesItem.FindAsync(id);

//                if (SalesItem == null)
//                {
//                    return NotFound();
//                }

//                return SalesItem;
//            }
//            catch (Exception e)
//            {
//                return Conflict(e);
//                throw e;
//            }

//        }

//        // GET: api/SalesItem/5
//        [HttpGet("GetSalesItemAll")]
//        public async Task<ActionResult<List<SalesItem>>> GetSalesItemAll()
//        {
//            try
//            {
//                var SalesItems = await _context.SalesItem.ToListAsync();

//                if (SalesItems == null)
//                {
//                    return NotFound();
//                }

//                return SalesItems;
//            }
//            catch (Exception e)
//            {

//                return Conflict();
//                throw e;
//            }

//        }


//        // PUT: api/SalesItem/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSalesItem(string id, SalesItem SalesItem)
//        {
//            if (id != SalesItem.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(SalesItem).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SalesItemExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/SalesItem
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<SalesItem>> PostSalesItem(SalesItem SalesItem)
//        {
//            _context.SalesItem.Add(SalesItem);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSalesItem", new { id = SalesItem.Id }, SalesItem);
//        }

//        // DELETE: api/SalesItem/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<SalesItem>> DeleteSalesItem(string id)
//        {
//            var SalesItem = await _context.SalesItem.FindAsync(id);
//            if (SalesItem == null)
//            {
//                return NotFound();
//            }

//            _context.SalesItem.Remove(SalesItem);
//            await _context.SaveChangesAsync();

//            return SalesItem;
//        }

//        private bool SalesItemExists(string id)
//        {
//            return _context.SalesItem.Any(e => e.Id == id);
//        }



//    }
//}
