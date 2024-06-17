namespace CSharpCodeReviewNUnitTest;

using CSharpCodeReview;
using NUnit.Framework;

[TestFixture]
    public class CalculatorUnitTest
    {
       
        [Test]
        public void TestAdd()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 5;

            // Act
            int result = calculator.Add(a, b);

            // Assert
           Assert.That(result, Is.EqualTo(15));

        }

        [Test]
        public void TestSubtract()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 5;

            // Act
            int result = calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
    }

    