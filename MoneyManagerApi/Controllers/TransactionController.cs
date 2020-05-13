using System.Collections.Generic;
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
        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactionRepository.GetAll();
        }

        // GET: api/Transactions/earnings
        /// <summary>
        /// Get all Transactions with a positive amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/earnings")]
        public IEnumerable<Transaction> GetEarnings()
        {
            return _transactionRepository.GetEarnings();
        }

        // GET: api/Transactions/expenses
        /// <summary>
        /// Get all Transactions with a negative amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/expenses")]
        public IEnumerable<Transaction> GetExpenses()
        {
            return _transactionRepository.GetExpenses();
        }

        // GET: api/Transactions/1
        /// <summary>
        /// Get a specific transaction based on ID
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Transaction GetTransactionById(int id)
        {
            return _transactionRepository.GetById(id);
        }

        // GET: api/Transactions/name/netflix
        /// <summary>
        /// Get a specific transaction based on the name
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public Transaction GetTransactionByName(string name)
        {
            return _transactionRepository.GetByName(name);
        }

        // GET: api/Transactions/type/1
        /// <summary>
        /// Get all the transaction of a certain frequency
        /// </summary>
        /// <returns>an array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/type/{type}")]
        public IEnumerable<Transaction> GetTransactionByFrequency(Frequency type)
        {
            return _transactionRepository.GetByType(type);
        }
        // POST: api/Transactions
        /// <summary>
        /// Adds a new transaction
        /// </summary>
        /// <param name="transactionDto">the new transaction</param>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Transaction> PostTransaction(TransactionDto transactionDto)
        {
            Transaction transactionToCreate = new Transaction(transactionDto.Name, transactionDto.TransactionFrequency, transactionDto.Amount, transactionDto.TransactionDateTime);
            _transactionRepository.Add(transactionToCreate);
            _transactionRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionToCreate.Id }, transactionToCreate);
        }
        // PUT: api/Transactions/3
        /// <summary>
        /// Modifies the amount of a transaction
        /// </summary>
        /// <param name="id">id of the transaction to be modified</param>
        /// <param name="transactionPatch">the modified transaction</param>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Transaction> PatchAmountTransaction(int id, TransactionPatchDto transactionPatch)
        {
            if (transactionPatch == null)
            {
                return BadRequest("please insert information");
            }

            Transaction currentTransaction = _transactionRepository.GetById(id);
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
            Transaction transaction = _transactionRepository.GetById(id);
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