using NUnit.Framework;
using Moq;
using backend.Services;
using backend.Adapters;
using NUnit.Framework.Legacy;

namespace backend.test.ServicesTest
{
    [TestFixture]
    public class VotingServiceTests
    {
        [Test]
        public async Task VoteForCat_ValidCatId_CallsVoteForCatInRepository()
        {
            // Arrange
            string catId = "123";

            // Mock 
            var mockVotingRepository = new Mock<IVotingRepository>();
            var votingService = new VotingService(mockVotingRepository.Object);

            // Act
            await votingService.VoteForCat(catId);

            // Assert
            mockVotingRepository.Verify(repo => repo.VoteForCat(catId), Times.Once);
        }

        [Test]
        public void VoteForCat_InvalidCatId_ThrowsException()
        {
            // Arrange
            string catId = "invalidId";

            // Mock of the voting repository
            var mockVotingRepository = new Mock<IVotingRepository>();
            mockVotingRepository.Setup(repo => repo.VoteForCat(catId)).ThrowsAsync(new Exception("Invalid cat ID"));
            var votingService = new VotingService(mockVotingRepository.Object);

            // Act & Assert
            var exception = ClassicAssert.ThrowsAsync<Exception>(() => votingService.VoteForCat(catId));
            ClassicAssert.AreEqual("Invalid cat ID", exception.Message);
        }
    }
}