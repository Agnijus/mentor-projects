using dotnet_phase1_app.Models;

namespace dotnet_phase1_app.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> InsertTransaction(string message);
    }
}
