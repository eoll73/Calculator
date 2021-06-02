using System;
using Xunit;

namespace Calculator.Teat
{
    public class MyCalculatorTests
    {
        [Fact]
        public void ShouldDoOperations()
        {
            double num1 = 1;
            double num2 = 2;

            Assert.Equal(num1 + num2, MyCalculator.DoOperation(num1, num2, "a"));
            Assert.Equal(num1 - num2, MyCalculator.DoOperation(num1, num2, "s"));
            Assert.Equal(num1 / num2, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(num1 * num2, MyCalculator.DoOperation(num1, num2, "*"));
        }

        [Fact]
        public void ShouldReturnNaN()
        {
            double num1 = 1;
            double num2 = 0;

            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "c"));
        }

        [Fact]

        public void ShouldReceiveUserInput()
        {
            IConsoleWrapper consoleWrapper = new MockConsoleWrapper();
            string userInput = consoleWrapper.ReadLine();
            Assert.Equal("5", userInput);
            string userInput2 = consoleWrapper.ReadLine();
            Assert.Equal("2", userInput2);
            string userInput3 = consoleWrapper.ReadLine();
            Assert.Equal("m", userInput3);
            string userInput4 = consoleWrapper.ReadLine();
            Assert.Equal("n", userInput4);
        }
        [Fact]
        public void ShouldMultiplyFiveAndTwo()
        {
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper();
            Program.RunCalculator(mockConsoleWrapper);
        }
    }

    public class MockConsoleWrapper : IConsoleWrapper
    {
        int count = 0;
        public string ReadLine()
        {
            count++;
            if (count == 1)
            {
                return "5";
            } else if (count == 2)
            {
                return "2";
            } else if (count == 3)
            {
                return "m";
            }
            return "n";
        }
    }
}
