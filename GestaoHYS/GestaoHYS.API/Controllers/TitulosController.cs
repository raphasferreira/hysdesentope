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
    public class TitulosController : ControllerBase
    {
        private ITitulosService _service;

        public TitulosController(ITitulosService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titulos>>> GetTitulos()
        {
            try
            {
                return Ok(await _service.GetTitulos());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar lista de usuários. Exception: { ex.Message }");
            }

        }

        // GET: api/Titulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titulos>> GetTitulos(long id)
        {
            try
            {
                var Titulos = await _service.FindTitulosById(id);

                if (Titulos == null)
                {
                    return NotFound();
                }

                return Ok(Titulos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário. Exception: { ex.Message }");
            }

        }

        // PUT: api/Titulos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutTitulos(Titulos titulos)
        {
            if (titulos.IdTitulos == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateTitulos(titulos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



       
    }
}
