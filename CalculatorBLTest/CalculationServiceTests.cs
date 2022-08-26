using CalculatorBL;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorTest
{
    public class CalculationServiceTests
    {
        CalculationService calculationService = new CalculationService();

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(20, 34, 54)]
        [InlineData(12.5, 24.4, 36.9)]
        [InlineData(-2, 1, -1)]
        public void Plus(decimal a, decimal b, decimal supposedResult)
        {
            var actualResult = calculationService.Plus(a, b);

            Assert.Equal(supposedResult, actualResult);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(14, 11, 3)]
        [InlineData(24.5, 12.1, 12.4)]
        [InlineData(-2, 1, -3)]
        public void Minus(decimal a, decimal b, decimal supposedResult)
        {
            var actualResult = calculationService.Minus(a, b);

            Assert.Equal(supposedResult, actualResult);
        }

        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(20, 34, 680)]
        [InlineData(12.5, 24.4, 305)]
        public void Multiply(decimal a, decimal b, decimal supposedResult)
        {
            var actualResult = calculationService.Multiply(a, b);

            Assert.Equal(supposedResult, actualResult);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(20, 10, 2)]
        [InlineData(18.8, 3.2, 5.875)]
        public void Divide(decimal a, decimal b, decimal supposedResult)
        {
            var actualResult = calculationService.Divide(a, b);

            Assert.Equal(supposedResult, actualResult);
        }

        [Theory]
        [InlineData(14, 22, "+", 36)]
        [InlineData(32, 12, "-", 20)]
        [InlineData(20, 34, "*", 680)]
        [InlineData(20, 10, "/", 2)]
        public void CalculatePerOperatorSign(decimal a, decimal b, string t, decimal supposedResult)
        {
            var actualResult = calculationService.CalculatePerOperatorSign(a, b, t);

            Assert.Equal(supposedResult, actualResult);
        }

        [Fact]
        public void PostfixQueueToResult()
        {
            var result = calculationService.PostfixQueueToResult(new Queue<string>(
            new string[]{
                "10",
                "2",
                "8",
                "*",
                "+",
                "3",
                "-"
            }));

            Assert.Equal(23, result);
        }

        [Theory]
        [InlineData('/', '+', -1)]
        [InlineData('/', '-', -1)]
        [InlineData('/', '/', -1)]
        [InlineData('*', '/', -1)]
        [InlineData('*', '*', -1)]
        [InlineData('/', '*', -1)]
        [InlineData('+', '*', 1)]
        [InlineData('-', '*', 1)]
        [InlineData('+', '/', 1)]
        [InlineData('-', '/', 1)]
        public void CompareOperators(char peek, char c, int supposedResult)
        {
            var actualResult = calculationService.CompareOperators(peek, c);

            Assert.Equal(supposedResult, actualResult);
        }

        [Theory]
        [InlineData(1, '3', 1, 1.3)]
        [InlineData(1.4, '3', 2, 1.43)]
        public void AddCharToDecimalPart(decimal dec, char chr, double power, decimal supposedResult)
        {
            var actualResult = calculationService.AddCharToDecimalPart(dec, chr, power);

            Assert.Equal(supposedResult, actualResult);

        }
        [Theory]
        [InlineData(1, '3', 13)]
        [InlineData(14, '3', 143)]
        public void AddCharToNumber(decimal dec, char chr, decimal supposedResult)
        {
            var actualResult = calculationService.AddCharToNumber(dec, chr);

            Assert.Equal(supposedResult, actualResult);
        }

        [Fact]
        public void AddLastSymbolsToQueue()
        {
            var stack = new Stack<char>(new char[] { '+' });
            var queue = new Queue<string>(new string[] { "32", "53" });
            calculationService.AddLastSymbolsToQueue(stack, queue);
            var result = "";
            while(queue.Count != 0)
            {
                result = queue.Dequeue();
            }
            Assert.Equal("+", result);
        }

        [Fact]
        public void FillPostfixQueue()
        {
            var stack = new Stack<char>();
            var queue = new Queue<string>();
            var str = "3+5*42+34";
            calculationService.FillPostfixQueue(str, queue, stack);

            Assert.Equal(6, queue.Count);
            Assert.Single(stack); //last operation sign
        }

        [Fact]
        public void ParseIntoPostfixQueue()
        {
            Queue<string> result = calculationService.ParseIntoPostfixQueue("3+5*42+34");

            Assert.Equal(7, result.Count);

            var actualString = "";

            var count = result.Count;

            for (int i = 0; i < count; i++)
            {
                actualString += result.Dequeue();
            }

            Assert.Equal("3542*+34+", actualString);
        }

        [Fact]
        public void Calculate()
        {
            var result = calculationService.Calculate("3.3+5*42+34/2+4.43");

            Assert.Equal((decimal)234.73, result);
        }
    }
}