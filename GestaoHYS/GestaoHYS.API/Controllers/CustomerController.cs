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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("GetClienteAllJasmin")]
        [Produces(typeof(IList<Cliente>))]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllCustomerAsync()
        {
            try
            {
                var list = await _service.GetAllCustomer();
                if (list.Count() == 0)
                    return NoContent();

                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no busca dos dados.{ex.Message}");
            }
        }
    }
}
