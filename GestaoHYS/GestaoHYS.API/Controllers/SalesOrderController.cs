using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoHIS.API.Helpers;
using GestaoHIS.API.Model;
using GestaoHIS.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {

        private readonly GestaoHISContext _context;
        internal static AuthenticationProvider AuthenticationProvider { get; set; }

        public SalesOrderController(GestaoHISContext context)
        {
            _context = context;

            AuthenticationProvider = new AuthenticationProvider("", "");
        }


        // GET: api/SalesOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrder()
        {
            return await _context.SalesOrder.ToListAsync();
        }

        // GET: api/SalesOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(string id)
        {
            try
            {
                var SalesOrder = await _context.SalesOrder.FindAsync(id);

                if (SalesOrder == null)
                {
                    return NotFound();
                }

                return SalesOrder;
            }
            catch (Exception e)
            {
                return Conflict(e);
                throw e;
            }

        }

        // GET: api/SalesOrder/5
        [HttpGet("GetSalesOrderAll")]
        public async Task<ActionResult<List<SalesOrder>>> GetSalesOrderAll()
        {
            try
            {
                var SalesOrders = await _context.SalesOrder.ToListAsync();

                if (SalesOrders == null)
                {
                    return NotFound();
                }

                return SalesOrders;
            }
            catch (Exception e)
            {

                return Conflict();
                throw e;
            }

        }


        // PUT: api/SalesOrder/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrder(string id, SalesOrder SalesOrder)
        {
            if (id != SalesOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(SalesOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderExists(id))
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

        // POST: api/SalesOrder
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SalesOrder>> PostSalesOrder(SalesOrder SalesOrder)
        {
            _context.SalesOrder.Add(SalesOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesOrder", new { id = SalesOrder.Id }, SalesOrder);
        }

        // DELETE: api/SalesOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesOrder>> DeleteSalesOrder(string id)
        {
            var SalesOrder = await _context.SalesOrder.FindAsync(id);
            if (SalesOrder == null)
            {
                return NotFound();
            }

            _context.SalesOrder.Remove(SalesOrder);
            await _context.SaveChangesAsync();

            return SalesOrder;
        }

        private bool SalesOrderExists(string id)
        {
            return _context.SalesOrder.Any(e => e.Id == id);
        }


    }
}
