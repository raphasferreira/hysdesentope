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
    [Authorize]
    public class SalesInvoiceController : ControllerBase
    {
        private ISalesInvoiceService _service;

        public SalesInvoiceController(ISalesInvoiceService service)
        {
            _service = service;
        }

        [HttpGet("GetSalesInvoiceAllJasmin")]
        [Produces(typeof(IList<SalesInvoice>))]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllSalesInvoiceAsync()
        {
            try
            {
                var list = await _service.GetAllSalesInvoice();
                if (list.Count() == 0)
                    return NoContent();

                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no busca dos dados.{ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesInvoice>>> GetSalesInvoices()
        {
            try
            {
                var list = await _service.FindAllAtivo();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de usuários. Exception: { ex.Message }");
            }

        }

        [HttpGet("GetSalesInvoicesAbertasLocais")]
        public async Task<ActionResult<IEnumerable<SalesInvoice>>> GetSalesInvoicesAbertasLocais()
        {
            try
            {
                var list = await _service.BuscaFaturasAbertasLocais();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de faturas abertas locais. Exception: { ex.Message }");
            }

        }

        // GET: api/SalesInvoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesInvoice>> GetSalesInvoice(long id)
        {
            try
            {
                var salesInvoice = await _service.FindById(id);

                if (salesInvoice == null)
                {
                    return NotFound();
                }

                return Ok(salesInvoice);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário. Exception: { ex.Message }");
            }

        }

        // PUT: api/SalesInvoice/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutSalesInvoice(SalesInvoice salesInvoice)
        {
            if (salesInvoice.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(salesInvoice);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST: api/SalesInvoice
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SalesInvoice>> PostSalesInvoice(SalesInvoice salesInvoice)
        {
            try
            {
                salesInvoice = await _service.Insert(salesInvoice);
                return CreatedAtAction("GetSalesInvoice", new { id = salesInvoice.Id }, salesInvoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/SalesInvoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSalesInvoice(long id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
