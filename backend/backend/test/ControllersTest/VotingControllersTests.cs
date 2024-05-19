using NUnit.Framework;
using Moq;
using backend.Core;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Legacy;

namespace backend.test.ControllersTest
{
    [TestFixture]
    public class VotingControllerTests
    {
        [Test]
        public async Task VoteForCat_ValidCatId_ReturnsOk()
        {
            // Arrange
            string catId = "123";

            // Mock 
            var mockVotingService = new Mock<IVotingService>();
            mockVotingService.Setup(service => service.VoteForCat(catId)).Verifiable();
            var controller = new VotingController(mockVotingService.Object);

            // Act
            var result = await controller.VoteForCat(catId);

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            ClassicAssert.AreEqual($"Vote recorded for the cat with ID {catId}", okResult.Value);
        }

        [Test]
        public async Task VoteForCat_InvalidCatId_ReturnsInternalServerError()
        {
            // Arrange
            string catId = "invalidId"; // Cat ID invalide à utiliser pour le test

            // Mock
            var mockVotingService = new Mock<IVotingService>();
            mockVotingService.Setup(service => service.VoteForCat(catId)).ThrowsAsync(new Exception("Invalid cat ID"));

            
            var controller = new VotingController(mockVotingService.Object);

            // Act
            var result = await controller.VoteForCat(catId);

            // Assert
            ClassicAssert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            ClassicAssert.AreEqual(500, objectResult.StatusCode); 
        }

    }
}
