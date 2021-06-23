using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaService _service;

        public EmpresaController(IEmpresaService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            try
            {
                return Ok(await _service.GetEmpresas());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de usuários. Exception: { ex.Message }");
            }

        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(long id)
        {
            try
            {
                var empresa = await _service.FindEmpresaById(id);

                if (empresa == null)
                {
                    return NotFound();
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário. Exception: { ex.Message }");
            }

        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutEmpresa(Empresa empresa)
        {
            if (empresa.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateEmpresa(empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST: api/Empresa
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            try
            {
                empresa = await _service.InsertEmpresa(empresa);
                return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmpresa(long id)
        {
            try
            {
                await _service.DeleteEmpresa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
