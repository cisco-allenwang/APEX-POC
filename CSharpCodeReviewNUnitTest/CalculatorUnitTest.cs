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

        
        [Test]
        public void TestDivide()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 5;

            // Act
            var result = calculator.Divide(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(2.0));
        }
         
        [Test]
        public void TestMod()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 5;

            // Act
            var result = calculator.Mod(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Test for Divide by zero
        [Test]
        public void TestDivideByZero()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 0;

            // Act and Assert
            Assert.That(() => calculator.Divide(a, b), Throws.TypeOf<DivideByZeroException>());
        }   

        // Test for Mod by zero
        [Test]
        public void TestModByZero()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 0;

            // Act and Assert
            Assert.That(() => calculator.Mod(a, b), Throws.TypeOf<DivideByZeroException>());
        }

        // Test for Multiply
        [Test]
        public void TestMultiply()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 5;

            // Act
            var result = calculator.Multiply(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(50));
        }

        // Test for Multiply by zero
        [Test]
        public void TestMultiplyByZero()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 0;

            // Act
            var result = calculator.Multiply(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

//test for power
        [Test]
        public void TestPower()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 2;
            int b = 3;

            // Act
            var result = calculator.Power(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        // Test for Power by zero
        [Test]
        public void TestPowerByZero()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 0;
            int b = 0;

            // Act
            var result = calculator.Power(a,b);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        
    
    }

    