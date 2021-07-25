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
    public class ItemTaxSchemasController : ControllerBase
    {
        private IItemTaxSchemasService _service;

        public ItemTaxSchemasController(IItemTaxSchemasService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<ItemTaxSchemas>))]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var list = await _service.GetAllItemTaxSchemas();
                if (list.Count() == 0)
                    return NoContent();

                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro na busca dos dados.{ex.Message}");
            }
        }
    }
}
