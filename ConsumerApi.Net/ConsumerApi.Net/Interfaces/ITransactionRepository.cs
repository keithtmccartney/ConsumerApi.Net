using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumerApi.Net.Models;
using ConsumerApi.Net.Repositories;

namespace ConsumerApi.Net.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction transaction);

        IEnumerable<Transaction> GetAll();

        Transaction GetById(int id);

        void Delete(Transaction transaction);
        void Update(Transaction transaction);
    }
}