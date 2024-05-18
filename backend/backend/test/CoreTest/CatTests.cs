using backend.Core;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace backend.test.CoreTest
{
    [TestFixture]
    public class CatTests
    {
        [Test]
        public void Cat_Id_CannotBeNullOrEmpty()
        {
            // Arrange
            Cat cat = new Cat();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => cat.Id = null);
            Assert.Throws<ArgumentException>(() => cat.Id = string.Empty);
        }

        [Test]
        public void Cat_Url_CannotBeNullOrEmpty()
        {
            // Arrange
            Cat cat = new Cat();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => cat.Url = null);
            Assert.Throws<ArgumentException>(() => cat.Url = string.Empty);
        }

        [Test]
        public void Cat_Score_ShouldBeGreaterThanOrEqualToZero()
        {
            // Arrange
            Cat cat = new Cat();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => cat.Score = -1);
        }

        [Test]
        public void Cat_Equality_Check()
        {
            // Arrange
            Cat cat1 = new Cat { Id = "123", Url = "https://example.com/cat1.jpg", Score = 10 };
            Cat cat2 = new Cat { Id = "123", Url = "https://example.com/cat1.jpg", Score = 10 };
            Cat cat3 = new Cat { Id = "456", Url = "https://example.com/cat3.jpg", Score = 15 };

            // Act & Assert
            ClassicAssert.AreEqual(cat1.Id, cat2.Id); // Same Id
            ClassicAssert.AreEqual(cat1.Url, cat2.Url); // Same Url
            ClassicAssert.AreEqual(cat1.Score, cat2.Score); // Same Score

            ClassicAssert.AreNotEqual(cat1.Id, cat3.Id); // Different Id
            ClassicAssert.AreNotEqual(cat1.Url, cat3.Url); // Different Url
            ClassicAssert.AreNotEqual(cat1.Score, cat3.Score); // Different Score 
        }

        [Test]
        public void Cat_JSON_Serialization_Deserialization()
        {
            // Arrange
            Cat originalCat = new Cat { Id = "789", Url = "https://example.com/cat.jpg", Score = 20 };
            Cat deserializedCat;
            string json;

            // Act
            json = JsonConvert.SerializeObject(originalCat);
            deserializedCat = JsonConvert.DeserializeObject<Cat>(json);

            // Assert
            ClassicAssert.AreEqual(deserializedCat.Url, originalCat.Url);
        }
        [Test]
        public void Cat_JSON_Serialization_Deserialization_ForScore()
        {
            // Arrange
            Cat originalCat = new Cat { Id = "789", Url = "https://example.com/cat.jpg", Score = 20 };
            Cat deserializedCat;
            string json;

            // Act
            json = JsonConvert.SerializeObject(originalCat);
            deserializedCat = JsonConvert.DeserializeObject<Cat>(json);

            // Assert
            ClassicAssert.AreEqual(deserializedCat.Score, originalCat.Score);
        }
        // Additional tests for etc. can be added here.
    }
}
