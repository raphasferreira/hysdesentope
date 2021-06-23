using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParceiroController : ControllerBase
    {
        private IParceiroService _service;

        public ParceiroController(IParceiroService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parceiro>>> GetParceiros()
        {
            try
            {
                return Ok(await _service.GetParceiros());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de usuários. Exception: { ex.Message }");
            }

        }

        // GET: api/Parceiro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parceiro>> GetParceiro(long id)
        {
            try
            {
                var parceiro = await _service.FindParceiroById(id);

                if (parceiro == null)
                {
                    return NotFound();
                }

                return Ok(parceiro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário. Exception: { ex.Message }");
            }

        }

        // PUT: api/Parceiro/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutParceiro(Parceiro parceiro)
        {
            if (parceiro.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateParceiro(parceiro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST: api/Parceiro
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Parceiro>> PostParceiro(Parceiro parceiro)
        {
            try
            {
                parceiro = await _service.InsertParceiro(parceiro);
                return CreatedAtAction("GetParceiro", new { id = parceiro.Id }, parceiro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Parceiro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParceiro(long id)
        {
            try
            {
                await _service.DeleteParceiro(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
