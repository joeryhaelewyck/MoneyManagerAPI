using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyManagerApi.DTOs;
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
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Cost getCostById(int id)
        {
            return _costRepository.getById(id);
        }
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public Cost getCostByName(string name)
        {
            return _costRepository.getByName(name);
        }
        [HttpGet]
        [Route("api/[controller]/type/{type}")]
        public IEnumerable<Cost> getCostsByType(string type)
        {
            return _costRepository.getByType(type);
        }
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Cost> PostCost(CostDTO costDTO)
        {
            Cost costToCreate = new Cost() { Name = costDTO.Name, Type = costDTO.Type, Amount = costDTO.Amount };
            _costRepository.Add(costToCreate);
            _costRepository.SaveChanges();

            return CreatedAtAction(nameof(getCostById), new { id = costToCreate.Id }, costToCreate);
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Cost> PatchAmountCost(int id,CostPatchDTO costPatch)
        {
            if(costPatch == null)
            {
                return BadRequest("please insert information");
            };
            if(_costRepository.getById(id) == null)
            {
                return NotFound();
            }
            Cost currentCost = _costRepository.getById(id);
            return _costRepository.UpdateAmount(currentCost, costPatch);
        }
    }
}