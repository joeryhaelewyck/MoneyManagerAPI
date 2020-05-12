using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyManagerApi.Data.Repositories.Contracts;
using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Transaction> getTransactions()
        {
            return _transactionRepository.getAll();
        }

        [HttpGet]
        [Route("api/[controller]/earnings")]
        public IEnumerable<Transaction> getEarnings()
        {
            return _transactionRepository.getEarnings();
        }

        [HttpGet]
        [Route("api/[controller]/expenses")]
        public IEnumerable<Transaction> getExpenses()
        {
            return _transactionRepository.getExpenses();
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Transaction getTransactionById(int id)
        {
            return _transactionRepository.getById(id);
        }

        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public Transaction getTransactionByName(string name)
        {
            return _transactionRepository.getByName(name);
        }

        [HttpGet]
        [Route("api/[controller]/type/{type}")]
        public IEnumerable<Transaction> getTransactionByFrequency(Frequency type)
        {
            return _transactionRepository.getByType(type);
        }

        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Transaction> PostTransaction(TransactionDTO transactionDTO)
        {
            Transaction transactionToCreate = new Transaction(transactionDTO.Name, transactionDTO.TransactionFrequency, transactionDTO.Amount, transactionDTO.TransactionDateTime);
            _transactionRepository.Add(transactionToCreate);
            _transactionRepository.SaveChanges();

            return CreatedAtAction(nameof(getTransactionById), new { id = transactionToCreate.Id }, transactionToCreate);
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Transaction> PatchAmountTransaction(int id,TransactionPatchDTO costPatch)
        {
            if(costPatch == null)
            {
                return BadRequest("please insert information");
            };
            Transaction currentCost = _transactionRepository.getById(id);
            if (currentCost == null)
            {
                return NotFound();
            }
            
            return _transactionRepository.UpdateAmount(currentCost, costPatch);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            Transaction cost = _transactionRepository.getById(id);
            if (cost == null)
            {
                return NotFound();
            }
            _transactionRepository.Delete(cost);
            _transactionRepository.SaveChanges();
            return NoContent();
        }
    }
}