using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsumerApi.Net.Interfaces;
using ConsumerApi.Net.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerApi.Net.Controllers
{
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET: transaction
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _transactionRepository.GetAll();
        }

        // GET transaction/5
        [HttpGet("{id}", Name = "GetTransaction")]
        public IActionResult Get(int id)
        {
            var _transaction = _transactionRepository.GetById(id);

            if (_transaction == null)
            {
                return NotFound();
            }

            return Ok(_transaction);
        }

        // POST transaction
        [HttpPost]
        public IActionResult Post([FromBody]Transaction _parameter)
        {
            if (_parameter == null)
            {
                return BadRequest();
            }

            var _transaction = _transactionRepository.Add(_parameter);

            return CreatedAtRoute("GetTransaction", new { id = _transaction.TransactionId }, _transaction);
        }

        // PUT transaction/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Transaction _parameter)
        {
            if (_parameter == null)
            {
                return BadRequest();
            }

            var _transaction = _transactionRepository.GetById(id);

            if (_transaction == null)
            {
                return NotFound();
            }

            _parameter.TransactionId = id;

            _transactionRepository.Update(_parameter);

            return NoContent();
        }

        // DELETE transaction/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _transaction = _transactionRepository.GetById(id);

            if (_transaction == null)
            {
                return NotFound();
            }

            _transactionRepository.Delete(_transaction);

            return NoContent();
        }
    }
}