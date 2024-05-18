using backend.Adapters;
using backend.Core;
using backend.Services;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace backend.test.ServicesTest
{
    [TestFixture]
    public class CatServiceTests
    {
        [Test]
        public async Task GetAllCats_ShouldReturnAllCats()
        {
            // Arrange
            var mockCatRepository = new Mock<ICatRepository>();
            var expectedCats = new List<Cat>
            {
                new Cat {Id = "1", Url = "https://example.com/cat1.jpg", Score = 10},
                new Cat {Id = "2", Url = "https://example.com/cat2.jpg", Score = 15}
            };
            mockCatRepository.Setup(repo => repo.GetAllCats()).ReturnsAsync(expectedCats);
            var catService = new CatService(mockCatRepository.Object);

            // Act
            var actualCats = await catService.GetAllCats();

            // Assert
            CollectionAssert.AreEquivalent(expectedCats, actualCats);
        }

        [Test]
        public async Task GetCatById_ExistingId_ShouldReturnMatchingCat()
        {
            // Arrange
            string expectedCatId = "1";
            var expectedCat = new Cat {Id = expectedCatId, Url = "https://example.com/cat1.jpg", Score = 10};

            var mockCatRepository = new Mock<ICatRepository>();
            mockCatRepository.Setup(repo => repo.GetAllCats()).ReturnsAsync(new List<Cat>
            {
                new Cat {Id = "1", Url = "https://example.com/cat1.jpg", Score = 10},
                new Cat {Id = "2", Url = "https://example.com/cat2.jpg", Score = 15},
                new Cat {Id = "3", Url = "https://example.com/cat3.jpg", Score = 20}
            });

            var catService = new CatService(mockCatRepository.Object);

            // Act
            var actualCat = await catService.GetCatById(expectedCatId);

            // Assert
            ClassicAssert.IsNotNull(actualCat);
            ClassicAssert.AreEqual(expectedCat.Id, actualCat.Id);
            ClassicAssert.AreEqual(expectedCat.Url, actualCat.Url);
            ClassicAssert.AreEqual(expectedCat.Score, actualCat.Score);
        }

        [Test]
        public async Task GetCatById_CatWithSpecifiedIdExists_ShouldReturnMatchingCat()
        {
            // Arrange
            string expectedCatId = "1";
            var expectedCat = new Cat {Id = expectedCatId, Url = "https://example.com/cat1.jpg", Score = 10};
            var mockCatRepository = new Mock<ICatRepository>();
            mockCatRepository.Setup(repo => repo.GetAllCats())
                .ReturnsAsync(new List<Cat> {expectedCat}); // Chat avec l'ID spécifié dans le repository
            var catService = new CatService(mockCatRepository.Object);

            // Act
            var actualCat = await catService.GetCatById(expectedCatId);

            // Assert
            ClassicAssert.IsNotNull(actualCat);
            ClassicAssert.AreEqual(expectedCatId, actualCat.Id);
            ClassicAssert.AreEqual(expectedCat.Url, actualCat.Url);
            ClassicAssert.AreEqual(expectedCat.Score, actualCat.Score);
        }

        [Test]
        public void GetCatById_CatWithSpecifiedIdDoesNotExist_ShouldThrowException()
        {
            // Arrange
            var mockCatRepository = new Mock<ICatRepository>();
            mockCatRepository.Setup(repo => repo.GetAllCats())
                .ReturnsAsync(new List<Cat>()); // Retourner une liste vide
            var catService = new CatService(mockCatRepository.Object);

            // Act & Assert
            var exception = ClassicAssert.Throws<AggregateException>(() =>
            {
                catService.GetCatById("100").Wait(); // ID inexistant
            });

            // Assert
            ClassicAssert.IsTrue(exception.InnerException is InvalidOperationException);
        }

        [Test]
        public async Task GetRandomCat_WhenCatsExist_ShouldReturnRandomCat()
        {
            // Arrange
            var cats = new List<Cat>
            {
                new Cat {Id = "1", Url = "https://example.com/cat1.jpg", Score = 10},
                new Cat {Id = "2", Url = "https://example.com/cat2.jpg", Score = 15},
                new Cat {Id = "3", Url = "https://example.com/cat3.jpg", Score = 20}
            };

            var mockCatRepository = new Mock<ICatRepository>();
            mockCatRepository.Setup(repo => repo.GetAllCats()).ReturnsAsync(cats);

            var catService = new CatService(mockCatRepository.Object);

            // Act
            var cat1 = await catService.GetRandomCat();
            var cat2 = await catService.GetRandomCat();

            // Assert
            ClassicAssert.IsNotNull(cat1);
            ClassicAssert.IsNotNull(cat2);
            ClassicAssert.AreNotEqual(cat1.Id, cat2.Id);
            ClassicAssert.IsTrue(cats.Contains(cat1));
            ClassicAssert.IsTrue(cats.Contains(cat2));
        }

        [Test]
        public async Task GetRandomCat_WhenNoCatsExist_ShouldThrowException()
        {
            // Arrange
            var mockCatRepository = new Mock<ICatRepository>();
            mockCatRepository.Setup(repo => repo.GetAllCats()).ReturnsAsync(new List<Cat>());

            var catService = new CatService(mockCatRepository.Object);

            // Act
            Exception caughtException = null;
            try
            {
                await catService.GetRandomCat();
            }
            catch (InvalidOperationException ex)
            {
                caughtException = ex;
            }

            // Assert
            ClassicAssert.IsNotNull(caughtException);
            ClassicAssert.AreEqual("No cats available.", caughtException.Message);
        }

    }
}
