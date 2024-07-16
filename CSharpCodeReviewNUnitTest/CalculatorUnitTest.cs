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
         
            int a = 10;
            int b = 5;

            // Act
            int result = Calculator.Instance.Add(a, b);

            // Assert
           Assert.That(result, Is.EqualTo(15));

        }

        [Test]
        public void TestSubtract()
        {
            // Arrange
        
            int a = 10;
            int b = 5;

            // Act
            int result = Calculator.Instance.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        
        [Test]
        public void TestDivide()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            var result = Calculator.Instance.Divide(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(2.0));
        }
         
        [Test]
        public void TestMod()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            var result = Calculator.Instance.Mod(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Test for Divide by zero
        [Test]
        public void TestDivideByZero()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act and Assert
            Assert.That(() => Calculator.Instance.Divide(a, b), Throws.TypeOf<DivideByZeroException>());
        }   

        // Test for Mod by zero
        [Test]
        public void TestModByZero()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act and Assert
            Assert.That(() => Calculator.Instance.Mod(a, b), Throws.TypeOf<DivideByZeroException>());
        }

        // Test for Multiply
        [Test]
        public void TestMultiply()
        {
            // Arrange

            int a = 10;
            int b = 5;

            // Act
            var result = Calculator.Instance.Multiply(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(50));
        }

        // Test for Multiply by zero
        [Test]
        public void TestMultiplyByZero()
        {
            // Arrange

            int a = 10;
            int b = 0;

            // Act
            var result = Calculator.Instance.Multiply(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

//test for power
        [Test]
        public void TestPower()
        {
            // Arrange
            int a = 2;
            int b = 3;

            // Act
            var result = Calculator.Instance.Power(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        // Test for Power by zero
        [Test]
        public void TestPowerByZero()
        {
            // Arrange
            int a = 0;
            int b = 0;

            // Act
            var result = Calculator.Instance.Power(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        
    
    }

    