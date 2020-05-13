using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoneyManagerApi.Data.Repositories.Contracts;
using MoneyManagerApi.DTOs;
using MoneyManagerApi.Mappers;
using MoneyManagerApi.Models;
using MoneyManagerApi.ViewModels;

namespace MoneyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionMapper _transactionMapper;

        public TransactionController(ITransactionRepository transactionRepository, TransactionMapper transactionMapper)
        {
            _transactionRepository = transactionRepository;
            _transactionMapper = transactionMapper;
        }
        // GET: api/Transactions
        /// <summary>
        /// Get all Transactions orderd by id
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<TransactionVM> GetTransactions()
        {
            var transactions = _transactionRepository.GetAll();
            return _transactionMapper.MapList(transactions);
        }

        // GET: api/Transactions/earnings
        /// <summary>
        /// Get all Transactions with a positive amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/earnings")]
        public IEnumerable<TransactionVM> GetEarnings()
        {
            var transactions= _transactionRepository.GetEarnings();
            return _transactionMapper.MapList(transactions);
        }

        // GET: api/Transactions/expenses
        /// <summary>
        /// Get all Transactions with a negative amount orderd by date
        /// </summary>
        /// <returns>array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/expenses")]
        public IEnumerable<TransactionVM> GetExpenses()
        {
            var transactions = _transactionRepository.GetExpenses();
            return _transactionMapper.MapList(transactions);
        }

        // GET: api/Transactions/1
        /// <summary>
        /// Get a specific transaction based on ID
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public TransactionVM GetTransactionById(int id)
        {
            var transaction = _transactionRepository.GetById(id);
            return _transactionMapper.Map(transaction);
        }

        // GET: api/Transactions/name/netflix
        /// <summary>
        /// Get a specific transaction based on the name
        /// </summary>
        /// <returns>one transaction</returns>
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public TransactionVM GetTransactionByName(string name)
        {
            var transaction = _transactionRepository.GetByName(name);
            return _transactionMapper.Map(transaction);
        }

        // GET: api/Transactions/type/1
        /// <summary>
        /// Get all the transaction of a certain frequency
        /// </summary>
        /// <returns>an array of transactions</returns>
        [HttpGet]
        [Route("api/[controller]/type/{type}")]
        public IEnumerable<TransactionVM> GetTransactionByFrequency(Frequency type)
        {
            var transactions = _transactionRepository.GetByType(type);
            return _transactionMapper.MapList(transactions);
        }
        // POST: api/Transactions
        /// <summary>
        /// Adds a new transaction
        /// </summary>
        /// <param name="transactionDto">the new transaction</param>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<TransactionVM> CreateTransaction(TransactionDto transactionDto)
        {
            var transaction = _transactionMapper.Map(transactionDto);
            _transactionRepository.Add(transaction);
            _transactionRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }
        // PUT: api/Transactions/3
        /// <summary>
        /// Modifies the amount of a transaction
        /// </summary>
        /// <param name="id">id of the transaction to be modified</param>
        /// <param name="amount">the modified transaction</param>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<TransactionVM> UpdateAmountTransaction(int id, decimal amount)
        {
            var currentTransaction = _transactionRepository.GetById(id);
            if (currentTransaction == null)
            {
                return NotFound();
            }

            var transaction = _transactionRepository.UpdateAmount(currentTransaction, amount);
            return _transactionMapper.Map(transaction);
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
            var transaction = _transactionRepository.GetById(id);
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