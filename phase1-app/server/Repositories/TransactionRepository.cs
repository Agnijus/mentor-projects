using Microsoft.Data.SqlClient;
using dotnet_phase1_app.Models;


namespace dotnet_phase1_app.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") + ";TrustServerCertificate=True";
        }
        public async Task<Transaction> InsertTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                await connection.OpenAsync();

                string query = "INSERT INTO [Transaction] (Message, Date) VALUES (@Message, @Date); SELECT SCOPE_IDENTITY(); ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Message", transaction.Message);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    var id = (decimal)await cmd.ExecuteScalarAsync();

                    transaction.Id = (int)id;

                    return transaction;
                }
            }
        }
    }
}
