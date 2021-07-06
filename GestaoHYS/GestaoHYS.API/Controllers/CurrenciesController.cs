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
    public class CurrenciesController : ControllerBase
    {
        private ICurrenciesService _service;

        public CurrenciesController(ICurrenciesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<Currencies>))]
        public async Task<ActionResult> GetAllCustomerAsync()
        {
            try
            {
                var list = await _service.GetAllCurrencies();
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
