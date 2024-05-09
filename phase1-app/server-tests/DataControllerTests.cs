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
        public async Task CreateTransaction_MessageInput_MustReturnNotNull()
        {
            // Arrange
            DataController dataController = new DataController(new TransactionRepositoryTest());

            // Act
            var result = await dataController.CreateTransaction("test");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateTransaction_EmptyMessage_ThrowsAnArgumentExceptionAsync()
        {
            // Arrange
            DataController dataController = new DataController(new TransactionRepositoryTest());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await dataController.CreateTransaction(""));

        }

        [Fact]
        public async Task CreateTransaction_MultipleMessages_MustContainMultipleEntries()
        {
            // Arrange
            TransactionRepositoryTest repositoryTest = new TransactionRepositoryTest();
            DataController dataController = new DataController(repositoryTest);


            // Act
            await dataController.CreateTransaction("test");
            await dataController.CreateTransaction("test1");
            await dataController.CreateTransaction("test2");

            // Assert

            Assert.Equal(3, repositoryTest.transactions.Count);

        }

    }
}
