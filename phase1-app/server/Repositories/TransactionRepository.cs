﻿using Microsoft.Data.SqlClient;
using dotnet_phase1_app.Models;
using Dapper;

namespace dotnet_phase1_app.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") + ";TrustServerCertificate=True";
        }
        public async Task<Transaction> InsertTransaction(string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                //await connection.OpenAsync();

                //string query = "INSERT INTO [Transaction] (Message, Date) VALUES (@Message, @Date); SELECT SCOPE_IDENTITY(); ";

                //using (SqlCommand cmd = new SqlCommand(query, connection))
                //{
                //    cmd.Parameters.AddWithValue("@Message", message);
                //    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                //    var id = (decimal)await cmd.ExecuteScalarAsync();


                //    return new Transaction
                //    {
                //        Id = (int)id,
                //        Message = message,
                //        Date = DateTime.Now
                //    };
                //}

                string query = @"
                    INSERT INTO [Transaction] (Message, Date)
                    OUTPUT INSERTED.Id, INSERTED.Message, INSERTED.Date
                    VALUES (@Message, @Date);"; 
                
                var transaction = await connection.QuerySingleAsync<Transaction>(query, new
                {
                    Message = message,
                    Date = DateTime.Now
                });


                return transaction;
            }
        }
    }
}
