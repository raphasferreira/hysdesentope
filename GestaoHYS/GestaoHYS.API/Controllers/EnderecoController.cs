using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestaoHIS.API.Repository;
using Microsoft.Extensions.Configuration;

namespace GestaoHIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IGestaoHISRepository _repo;
        private readonly IConfiguration _config;

        public EnderecoController(IGestaoHISRepository smartImoveisRepository, IConfiguration config)
        {
            _repo = smartImoveisRepository;
            _config = config;
        }

    }
}
