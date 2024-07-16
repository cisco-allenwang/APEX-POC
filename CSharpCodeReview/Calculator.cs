using System;
namespace CSharpCodeReview
{

    public class Calculator
    {
        // Singleton instance
        private static Calculator instance;

        // Private constructor to prevent instantiation
        private Calculator()
        {
        }

        // Get the singleton instance
        public static Calculator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Calculator();
                }
                return instance;
            }
        }

        // Perform addition
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Perform subtraction
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // Perform multiplication
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Perform division
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }

        // Perform modulo operation
        public int Mod(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a % b;
        }

        // Perform power operation
        public double Power(int a, int b)
        {
            return Math.Pow(a, b);
        }
    }
 }
