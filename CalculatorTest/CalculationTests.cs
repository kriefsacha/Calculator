using CalculatorAPI.Controllers;
using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace CalculatorTest
{
    public class CalculationTests
    {
        CalculationController calculationController;
        Mock<ICalculationService> calculationService;
        public CalculationTests()
        {
            calculationService = new Mock<ICalculationService>();
            calculationController = new CalculationController(calculationService.Object);
        }
            
        [Theory]
        [InlineData("10+25*35/14+15*2+0.52",103.02 )]
        [InlineData("32-42*2/4+53.4", 64.4)]
        public void Calculate(string str, decimal expectedResult)
        {
            var model = new CalculateModel() { Expression = str };

            calculationService.Setup((cs) => cs.Calculate(str)).Returns(expectedResult);

            var res = calculationController.Calculate(model);

            Assert.IsType<OkObjectResult>(res);

            var actualResult = (res as OkObjectResult).Value;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Calculate_DivideByZero_BadRequest()
        {
            var expression = "3/0+4";

            var model = new CalculateModel() { Expression = expression };

            calculationService.Setup((cs) => cs.Calculate(expression)).Throws(new Exception("Attempted to divde by zero"));

            var res = calculationController.Calculate(model);

            Assert.IsType<BadRequestObjectResult>(res);
        }
    }
}
