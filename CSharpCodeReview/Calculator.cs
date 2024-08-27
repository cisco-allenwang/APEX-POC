using System;
namespace CSharpCodeReview
{
    public class Calculator
    {

        public int Add(int a, int b)
        {
            // Perform addition
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            // Perform subtraction
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }

        //create Mod function
        public int Mod(int a, int b)
        {
            return a % b;
        }

        //Create a Square  Root function
        public double SquareRoot(int a)
        {
            return Math.Sqrt(a);
        }

        //add power function
        public int Power(int a, int b)
        {
            return (int)Math.Pow(a, b);
        }   


    }

}
