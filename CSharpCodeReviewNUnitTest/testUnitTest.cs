
namespace CSharpCodeReviewNUnitTest;

using CSharpCodeReview;
using NUnit.Framework;


[TestFixture]
public class YourClassTests
{
    

     private HilhdaselloePR _yourClass;

        [SetUp]
        public void Setup()
        {
            _yourClass = new HilhdaselloePR();
        }

        [Test]
        public void Greet_WithNullOrEmptyName_ReturnsHelloGuest()
        {
            // Arrange
            string name = null;

            // Act
            var result = _yourClass.Greet(name);

            // Assert
            Assert.That(result, Is.EqualTo("Hello, Guest!"));

            // Test with empty string
            name = string.Empty;

            // Act
            result = _yourClass.Greet(name);

            // Assert
            Assert.That(result, Is.EqualTo("Hello, Guest!"));
        }

        [Test]
        public void Greet_WithValidName_ReturnsHelloName()
        {
            // Arrange
            string name = "John";

            // Act
            var result = _yourClass.Greet(name);

            // Assert
            Assert.That(result, Is.EqualTo($"Hello, {name}!"));
        }

        [Test]
        public void Grtesteet_WithNullOrEmptyName_ReturnsHelloGuest()
        {
            // Arrange
            string name = null;

            // Act
            var result = _yourClass.Grtesteet(name);

            // Assert
            Assert.That(result, Is.EqualTo("Hello, Guest!"));

            // Test with empty string
            name = string.Empty;

            // Act
            result = _yourClass.Grtesteet(name);

            // Assert
            Assert.That(result, Is.EqualTo("Hello, Guest!"));
        }

        [Test]
        public void Grtesteet_WithValidName_ReturnsHelloName()
        {
            // Arrange
            string name = "Jane";

            // Act
            var result = _yourClass.Grtesteet(name);

            // Assert
            Assert.That(result, Is.EqualTo($"Hello, {name}!"));
        }
}