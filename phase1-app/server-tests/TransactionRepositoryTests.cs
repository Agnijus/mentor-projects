﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_phase1_app.Models;
using dotnet_phase1_app.Repositories;

namespace server_tests
{
    internal class TransactionRepositoryTest : ITransactionRepository
    {
        public List<Transaction> transactions = new List<Transaction>();
        private int IdCount = 1;

        public Task<Transaction> InsertTransaction(string message)
        {
            var transaction = new Transaction
            {
                Id = IdCount++,
                Message = message,
                Date = DateTime.Now,
            };

            transactions.Add(transaction);

            return Task.FromResult(transaction);
        }

    }
}
