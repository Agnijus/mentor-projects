using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using dotnet_phase1_app.Models;
using dotnet_phase1_app.Repositories;
using System.Transactions;


namespace dotnet_phase1_app.Controllers
{

    [Route("/api/transaction")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository; 


        public DataController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateTransaction([FromQuery] string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message parameter is required.");
            }

            try
            {
                var Transaction = await _transactionRepository.InsertTransaction(message);
                Console.WriteLine(Transaction);
                return Ok(new { Id = Transaction.Id, Message = Transaction.Message, Date = Transaction.Date, isSuccess = true, StatusCode = 200, Text = "Got It" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Unable to to connect to database: {ex.Message}");
            }
        }

    }
}
