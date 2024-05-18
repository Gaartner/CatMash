using backend.Controllers;
using backend.Core;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace backend.test.ControllersTest
{
    public class CatControllersTests
    {
        private Mock<ICatService> _mockCatService;
        private CatControllers _controller;

        [SetUp]
        public void Setup()
        {
            _mockCatService = new Mock<ICatService>();
            _controller = new CatControllers(_mockCatService.Object);
        }

        [Test]
        public async Task GetAllCats_ShouldReturnOkWithListOfCats()
        {
            // Arrange
            var expectedCats = new List<Cat>
            {
                new Cat { Id = "1", Url = "https://example.com/cat1.jpg", Score = 10 },
                new Cat { Id = "2", Url = "https://example.com/cat2.jpg", Score = 15 }
            };
            _mockCatService.Setup(service => service.GetAllCats()).ReturnsAsync(expectedCats);

            // Act
            var result = await _controller.GetAllCats();

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult);
            ClassicAssert.AreEqual(expectedCats, okResult.Value);
        }

        [Test]
        public async Task GetCatById_ExistingId_ShouldReturnOkWithCat()
        {
            // Arrange
            var expectedCat = new Cat { Id = "1", Url = "https://example.com/cat1.jpg", Score = 10 };
            _mockCatService.Setup(service => service.GetCatById("1")).ReturnsAsync(expectedCat);

            // Act
            var result = await _controller.GetCatById("1");

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult);
            ClassicAssert.AreEqual(expectedCat, okResult.Value);
        }

        [Test]
        public async Task GetCatById_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            _mockCatService.Setup(service => service.GetCatById("non-existing-id")).ReturnsAsync((Cat)null);

            // Act
            var result = await _controller.GetCatById("non-existing-id");

            // Assert
            ClassicAssert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetRandomCat_ShouldReturnOkWithRandomCat()
        {
            // Arrange
            var expectedCat = new Cat { Id = "1", Url = "https://example.com/cat1.jpg", Score = 10 };
            _mockCatService.Setup(service => service.GetRandomCat()).ReturnsAsync(expectedCat);

            // Act
            var result = await _controller.GetRandomCat();

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult);
            ClassicAssert.AreEqual(expectedCat, okResult.Value);
        }

        [Test]
        public async Task GetRandomCat_WhenNoCats_ShouldReturnNotFound()
        {
            // Arrange
            _mockCatService.Setup(service => service.GetRandomCat()).ReturnsAsync((Cat)null);

            // Act
            var result = await _controller.GetRandomCat();

            // Assert
            ClassicAssert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
