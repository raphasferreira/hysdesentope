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
    public class DeliveryTermsController : ControllerBase
    {
        private IDeliveryTermsService _service;

        public DeliveryTermsController(IDeliveryTermsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<DeliveryTerms>))]
        public async Task<ActionResult> GetAllCustomerAsync()
        {
            try
            {
                var list = await _service.GetAllDeliveryTerms();
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
