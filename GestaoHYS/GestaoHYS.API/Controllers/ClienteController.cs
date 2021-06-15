using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoHIS.API.Model;
using GestaoHIS.API.Repository;
using System.Net.Http;
using GestaoHIS.API.Helpers;
using Newtonsoft.Json;
using GestaoHIS.API.Extensions;
using Microsoft.Extensions.Configuration;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly GestaoHISContext _context;
        private readonly IGestaoHISRepository _repo;
        //private readonly IConfiguration _config;
        internal static AuthenticationProvider AuthenticationProvider { get; set; }

        public ClienteController(GestaoHISContext context, IGestaoHISRepository repo)//, IConfiguration config)
        {
            _context = context;
            _repo = repo;
            //_config = config;
            AuthenticationProvider = new AuthenticationProvider("", "");
        }


        #region Public Properties

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        public static string AccountKey { get; set; }

        /// <summary>
        /// Gets or sets the subscription key.
        /// </summary>
        public static string SubscriptionKey { get; set; }

        /// <summary>
        /// Gets or sets the culture key.
        /// </summary>
        public static string CultureKey { get; set; }


        #endregion

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.Cliente.Where(w => w.IsDeleted == false).ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(long id)
        {
            try
            {
                var cliente = await _context.Cliente.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente;
            }
            catch (Exception e)
            {
                return Conflict(e);
                throw e;
            }
        }


        [HttpGet("GetClienteAll")]
        public async Task<ActionResult<Cliente[]>> GetClienteAll()
        {
            try
            {
                var clientes = await _repo.GetAllClienteAsync();

                if (clientes == null)
                {
                    return NotFound();
                }

                return clientes;
            }
            catch (Exception e)
            {

                return Conflict();
                throw e;
            }
           
        }


        [HttpGet("GetClienteAllJasmin")]
        public async Task<Cliente[]> GetAllCustomerAsync(bool silentMode = false)
        {
            try
            {
                // Create the HTTP client to perform the request

                using HttpClient client = new HttpClient();
                await AuthenticationProvider.SetAccessTokenAsync(client);

                // Build the request

                string request = "salescore/customerParties";

                // build the odata expression

                //string odataExpression = "?$select=PartyKey, PaymentTerm&$top=1&$filter= IsActive eq true and IsSystem eq false and IsDeleted eq false&$orderby=CreatedOn desc";

                // full request 
                request = string.Concat(request);

                string resourceLocation = string.Format("{0}/api/{1}/{2}/{3}", Constants.baseAppUrl, Constants.AccountKey, Constants.SubscriptionKey, request);

                client.SetDefaultRequestHeaders(CultureKey);

                if (!silentMode)
                {
                    // Log Request

                    Console.WriteLine("Request - GET");
                    Console.WriteLine("{0}", resourceLocation);
                }

                // Send

                using HttpResponseMessage responseContent = await client.GetAsync(resourceLocation);
                // Get the response

                if (responseContent.IsSuccessStatusCode)
                {
                    string json = await ((StreamContent)responseContent.Content).ReadAsStringAsync();

                    var objectResult = JsonConvert.DeserializeObject<ODataResponse<Cliente>>(json);
                    Cliente[] customers = objectResult.Items.ToArray();

                    var foundPartyKey = customers[0].PartyKey;

                    if (!silentMode)
                    {
                        //ConsoleHelper.WriteSuccessLine(string.Format("The last customer was found with success. ('{0}' - PaymentTerm:{1})", foundPartyKey, customers[0].PaymentTerm));
                        Console.WriteLine("");
                    }
                    return customers;
                }
                else
                {
                    if (!silentMode)
                    {
                        //ConsoleHelper.WriteErrorLine(string.Format("Failed. {0}", responseContent.ToString()));
                        string result = await ((StreamContent)responseContent.Content).ReadAsStringAsync();
                        //ConsoleHelper.WriteErrorLine(string.Format("Content: {0}", result));

                        throw new Exception("Unable to get the last customer.");
                    }
                }
            }
            catch (Exception)
            {
                //ConsoleHelper.WriteErrorLine("Error found!");
                //ConsoleHelper.WriteErrorLine(exception.Message);
                throw new Exception("Error getting the last customer.");
            }

            return null;
        }



        [HttpPut("")]
        public async Task<IActionResult> PutCliente(Cliente cliente)
        {
            if (!ClienteExists(cliente.Id))
            {
                return NotFound();
            }

            _repo.Update(cliente);
            //_context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _repo.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _repo.Add(cliente);
            await _repo.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(long id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.IsDeleted = true;
            _repo.Update(cliente);

            try
            {
                await _repo.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ClienteExists(long id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
