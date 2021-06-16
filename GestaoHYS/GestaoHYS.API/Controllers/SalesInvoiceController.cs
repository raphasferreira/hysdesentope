//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GestaoHIS.API.Helpers;
//using GestaoHIS.API.Model;
//using GestaoHIS.API.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace GestaoHYS.Core.Models
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SalesInvoiceController : ControllerBase
//    {

//        private readonly GestaoHISContext _context;
//        internal static AuthenticationProvider AuthenticationProvider { get; set; }

//        public SalesInvoiceController(GestaoHISContext context)
//        {
//            _context = context;

//            AuthenticationProvider = new AuthenticationProvider("", "");
//        }


//        // GET: api/SalesInvoice
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SalesInvoice>>> GetSalesInvoice()
//        {
//            return await _context.SalesInvoice.ToListAsync();
//        }

//        // GET: api/SalesInvoice/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SalesInvoice>> GetSalesInvoice(string id)
//        {
//            try
//            {
//                var SalesInvoice = await _context.SalesInvoice.FindAsync(id);

//                if (SalesInvoice == null)
//                {
//                    return NotFound();
//                }

//                return SalesInvoice;
//            }
//            catch (Exception e)
//            {
//                return Conflict(e);
//                throw e;
//            }

//        }

//        // GET: api/SalesInvoice/5
//        [HttpGet("GetSalesInvoiceAll")]
//        public async Task<ActionResult<List<SalesInvoice>>> GetSalesInvoiceAll()
//        {
//            try
//            {
//                var SalesInvoices = await _context.SalesInvoice.ToListAsync();

//                if (SalesInvoices == null)
//                {
//                    return NotFound();
//                }

//                return SalesInvoices;
//            }
//            catch (Exception e)
//            {

//                return Conflict();
//                throw e;
//            }

//        }


//        // PUT: api/SalesInvoice/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSalesInvoice(string id, SalesInvoice SalesInvoice)
//        {
//            if (id != SalesInvoice.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(SalesInvoice).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SalesInvoiceExists(id))
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

//        // POST: api/SalesInvoice
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<SalesInvoice>> PostSalesInvoice(SalesInvoice SalesInvoice)
//        {
//            _context.SalesInvoice.Add(SalesInvoice);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSalesInvoice", new { id = SalesInvoice.Id }, SalesInvoice);
//        }

//        // DELETE: api/SalesInvoice/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<SalesInvoice>> DeleteSalesInvoice(string id)
//        {
//            var SalesInvoice = await _context.SalesInvoice.FindAsync(id);
//            if (SalesInvoice == null)
//            {
//                return NotFound();
//            }

//            _context.SalesInvoice.Remove(SalesInvoice);
//            await _context.SaveChangesAsync();

//            return SalesInvoice;
//        }

//        private bool SalesInvoiceExists(string id)
//        {
//            return _context.SalesInvoice.Any(e => e.Id == id);
//        }


//    }
//}
