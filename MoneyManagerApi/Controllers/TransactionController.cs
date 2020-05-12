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
        // GET: api/Transactions
        /// <summary>
        /// Get all Transactions orderd by id
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Transaction> getTransactions()
        {
            return _transactionRepository.getAll();
        }

        // GET: api/Transactions/earnings
        /// <summary>
        /// Get all Transactions with a positive amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/earnings")]
        public IEnumerable<Transaction> getEarnings()
        {
            return _transactionRepository.getEarnings();
        }

        // GET: api/Transactions/expenses
        /// <summary>
        /// Get all Transactions with a negative amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/expenses")]
        public IEnumerable<Transaction> getExpenses()
        {
            return _transactionRepository.getExpenses();
        }

        // GET: api/Transactions/1
        /// <summary>
        /// Get a specific transaction based on ID
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Transaction getTransactionById(int id)
        {
            return _transactionRepository.getById(id);
        }

        // GET: api/Transactions/name/netflix
        /// <summary>
        /// Get a specific transaction based on the name
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public Transaction getTransactionByName(string name)
        {
            return _transactionRepository.getByName(name);
        }

        // GET: api/Transactions/type/1
        /// <summary>
        /// Get all the transaction of a certain frequency
        /// </summary>
        /// <returns>an array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/type/{type}")]
        public IEnumerable<Transaction> getTransactionByFrequency(Frequency type)
        {
            return _transactionRepository.getByType(type);
        }
        // POST: api/Transactions
        /// <summary>
        /// Adds a new transaction
        /// </summary>
        /// <param name="transactionDTO">the new transaction</param>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Transaction> PostTransaction(TransactionDTO transactionDTO)
        {
            Transaction transactionToCreate = new Transaction(transactionDTO.Name, transactionDTO.TransactionFrequency, transactionDTO.Amount, transactionDTO.TransactionDateTime);
            _transactionRepository.Add(transactionToCreate);
            _transactionRepository.SaveChanges();

            return CreatedAtAction(nameof(getTransactionById), new { id = transactionToCreate.Id }, transactionToCreate);
        }
        // PUT: api/Transactions/3
        /// <summary>
        /// Modifies the amount of a transaction
        /// </summary>
        /// <param name="id">id of the transaction to be modified</param>
        /// <param name="transactionPatch">the modified transaction</param>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Transaction> PatchAmountTransaction(int id, TransactionPatchDTO transactionPatch)
        {
            if (transactionPatch == null)
            {
                return BadRequest("please insert information");
            };
            Transaction currentTransaction = _transactionRepository.getById(id);
            if (currentTransaction == null)
            {
                return NotFound();
            }

            return _transactionRepository.UpdateAmount(currentTransaction, transactionPatch);
        }

        // DELETE: api/Transactions/3
        /// <summary>
        /// Deletes a transaction
        /// </summary>
        /// <param name="id">the id of the transaction to be deleted</param>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            Transaction transaction = _transactionRepository.getById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            _transactionRepository.Delete(transaction);
            _transactionRepository.SaveChanges();
            return NoContent();
        }
    }
}