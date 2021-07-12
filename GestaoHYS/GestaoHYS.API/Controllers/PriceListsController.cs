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
    public class PriceListsController : ControllerBase
    {
        private IPriceListsService _service;

        public PriceListsController(IPriceListsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<PriceLists>))]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var list = await _service.GetAllPriceLists();
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
