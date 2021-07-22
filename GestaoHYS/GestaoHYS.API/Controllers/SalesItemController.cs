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
    public class SalesItemController : ControllerBase
    {
        private ISalesItemService _service;

        public SalesItemController(ISalesItemService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<SalesItem>))]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var list = await _service.FindAllAtivo();
                if (list.Count() == 0)
                    return NoContent();

                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro na busca dos dados.{ex.Message}");
            }
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetArtigoVenda(long id)
        {
            try
            {
                var artigo = await _service.FindById(id);

                if (artigo == null)
                {
                    return NotFound();
                }

                return Ok(artigo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar artigo de venda. Exception: { ex.Message }");
            }

        }

        [HttpPost]
        public async Task<ActionResult<SalesItem>> PostSalesItem(SalesItem artigo)
        {
            try
            {
                artigo = await _service.Insert(artigo);
                return CreatedAtAction("GetArtigoVenda", new { id = artigo.Id }, artigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> PutSalesItem(SalesItem artigo)
        {
            if (artigo.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(artigo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtigoVenda(long id)
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
