using dotnet_phase1_app.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_phase1_app.Controllers;

namespace server_tests
{
    public class DataControllerTests
    {
        
        [Fact]
        public void CreateTransaction_MessageInput_MustReturnTransaction()
        {
            // Arrange
            DataController dataController = new DataController(new TransactionRepositoryTest());

            // Act
            var transaction = dataController.CreateTransaction("test");

            // Assert
            Assert.NotNull(transaction); 

        }

        [Fact]
        public void CreateTransaction_EmptyMessage_ThrowsAnException()
        {
            // Arrange
            DataController dataController = new DataController(new TransactionRepositoryTest());

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => dataController.CreateTransaction(""));

        }

    }
}
