using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using dotnet_phase1_app.Models;
using dotnet_phase1_app.Repositories;


namespace dotnet_phase1_app.Controllers
{

    [Route("/api/transaction")]
    [ApiController]
    public class DataController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        private readonly ITransactionRepository _transactionRepository; 


        public DataController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null) {
                return BadRequest("No data present");
            }

            try
            {
                var Transaction = await _transactionRepository.InsertTransaction(transaction);
                return CreatedAtAction(nameof(CreateTransaction), Transaction, new { id = Transaction.Id });


            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Unable to to connect to database: {ex.Message}");
            }
        }

    }
}
