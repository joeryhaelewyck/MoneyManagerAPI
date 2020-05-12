using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly ICostRepository _costRepository;
        public CostController(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Cost> getCosts()
        {
            return _costRepository.getAll();
        }
    }
}